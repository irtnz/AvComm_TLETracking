using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDPTest
{
	public partial class Form1 : Form
	{
		private const string QueryACUCmd = "0";
		private const string QueryStatusCmd = "1";
		private const string QueryPulseCmd = "?";

		private Dictionary<string, string> _cmds;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			// get ACU ip and port from settings
			textBoxIP.Text = Properties.Settings.Default.acuIP;
			textBoxPort.Text = Properties.Settings.Default.acuPort;
			textBoxLPort.Text = Properties.Settings.Default.localPort;

			// load commands
			_cmds = Util.LoadCommands( "commands.txt" );
			foreach( string s in _cmds.Keys )
			{
				comboBox1.Items.Add( s );
			}
			comboBox1.SelectedIndex = 0;
		}

		private void Form1_FormClosing( object sender, FormClosingEventArgs e )
		{
			// save ACU ip and port to settings
			Properties.Settings.Default.acuIP = textBoxIP.Text;
			Properties.Settings.Default.acuPort = textBoxPort.Text;
			Properties.Settings.Default.localPort = textBoxLPort.Text;
			Properties.Settings.Default.Save();
		}

		private string sendEncap( string data )
		{
			return Program.SendEncap
			(
				int.Parse( textBoxLPort.Text ),
				textBoxIP.Text,
				int.Parse( textBoxPort.Text ),
				data,
				logListView.Append
			);
		}

		private void btnQuery_Click( object sender, EventArgs e )
		{
			// send query ACU command
			sendEncap( QueryACUCmd );
		}

		private void btnBoardcast_Click( object sender, EventArgs e )
		{
			Util.BroadcastQuery( logListView.Append );
		}

		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			txtBox1.Text = _cmds[ comboBox1.Text ];
		}

		private void btnSend_Click( object sender, EventArgs e )
		{
			// send predefined command
			sendEncap( txtBox1.Text );
		}

		#region Auto Status Functions

		private int _status_index = 0;

		private void timer1_Start( object sender, EventArgs e )
		{
			_status_index = 0;
			timer1.Interval = int.Parse( textBoxStatusInterval.Text );
			timer1.Start();

			textBoxStatusInterval.Enabled = false;
			btnStatusStart.Enabled = false;
			btnStatusStop.Enabled = true;
		}

		private void timer1_Stop( object sender, EventArgs e )
		{
			timer1.Stop();

			textBoxStatusInterval.Enabled = true;
			btnStatusStart.Enabled = true;
			btnStatusStop.Enabled = false;
		}

		private void timer1_Tick( object sender, EventArgs e )
		{
			string[] cmds =
			{
				QueryStatusCmd,
				QueryPulseCmd
			};

			sendEncap( cmds[ _status_index ] );
			_status_index = ( _status_index + 1 ) % cmds.Length;
		}

		#endregion

		#region Sat Data Functions

		private void btnFill_Click( object sender, EventArgs e )
		{
			string cmd;

			for( int n = 0; n < 100; n++ )
			{
				int trk = 0;
				if( ( n % 6 == 0 ) || ( n % 11 == 0 ) )
				{
					trk = n % 5;
				}

				cmd = String.Format
				(
					"9{0:D3}SAT {0,-6:D3}{1,6:F1}{2:D2}{3}  0.0{4}{5}" +
					"{6,8:F3}{7,8:F3}{8,8:F3}{9,8:F3}        ",
					n + 1,
					-95.0,
					0,
					1,
					trk,
					1,
					181.300,
					44.900,
					11.456,
					-78.544
				);
				sendEncap( cmd );

				if( trk < 3 ) continue;

				cmd = String.Format
				(
					";{0:D3}{1}{2}",
					n + 1,
					"1 27445U 02030A   16146.53207439  .00000000  00000-0  10000-3 0  9992",
					"2 27445   0.0155  18.5746 0002070 336.8761 344.5323  1.00265907 51100"
				);
				sendEncap( cmd );
			}

			sendEncap( "ISAVE" );
		}

		private void btnReadAllTLE_Click( object sender, EventArgs e )
		{
			string cmd;

			for( int n = 0; n < 100; n++ )
			{
				cmd = String.Format( "<{0:D3}", n + 1 );
				sendEncap( cmd );
			}
		}

		#endregion

		#region Config Data Functions

		private void btnCfgDown_Click( object sender, EventArgs e )
		{
			configDownload( "A" );
		}

		private void btnSatDown_Click( object sender, EventArgs e )
		{
			configDownload( "B" );
		}

		private void configDownload( string mask )
		{
			try
			{
				string r;
				string[] ss;
				int rt;

				// get version
				r = sendEncap( "J0.0.0" );
				ss = r.Substring( 2, r.Length - 4 ).Split( '=' );
				int version = int.Parse( ss[ 1 ] );

				// get max count
				r = sendEncap( "J0.1.0" );
				ss = r.Substring( 2, r.Length - 4 ).Split( '=' );
				int count = int.Parse( ss[ 1 ] );

				for( int n = 0; n < count; n++ )
				{
					for( int m = 0; ; m++ )
					{
						for( rt = 0; rt < 3; rt++ )
						{
							// send config read
							r = sendEncap( String.Format( "J{0}{1}.{2}.{3}", mask, version, n, m ) );

							// check ACK response
							if( ( r.Length > 0 ) && ( r[ 0 ] == 0x15 ) )
								break;
						}
						if( rt == 3 ) break;
					}
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message + "\r\n" + ex.StackTrace );
			}
		}

		private void btnCfgDown2_Click( object sender, EventArgs e )
		{
			configDownload2( "A" );
		}

		private void btnSatDown2_Click( object sender, EventArgs e )
		{
			configDownload2( "B" );
		}

		private void configDownload2( string mask )
		{
			try
			{
				int version = 0;
				int index = 0;
				int subindex = 0;
			
				while( true )
				{
					string r = "";
					string[] ss;
					int rt;

					for( rt = 0; rt < 3; rt++ )
					{
						// send config read
						r = sendEncap( String.Format( "J{0}{1}.{2}.{3}", mask, version, index, subindex ) );

						// check ACK response
						if( ( r.Length > 0 ) && ( r[ 0 ] == 0x06 ) )
							break;
					}
					if( rt == 3 ) break;

					// parse OID
					ss = r.Substring( 3, r.Length - 5 ).Split( new char[] { '.', '=' }, 4 );
					version = int.Parse( ss[ 0 ] );
					index = int.Parse( ss[ 1 ] );
					subindex = int.Parse( ss[ 2 ] );

					// advance subindex by 1 and repeat
					subindex++;
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message + "\r\n" + ex.StackTrace );
			}
		}

		#endregion
	}
}