using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDPTest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run( new Form1() );
		}

		public delegate void LogFunc( string[] text, Color color );

		public static string SendEncap( int lport, string ip, int port, string data, LogFunc logFunc )
		{
			// convert cmd to bytes
			byte[] bytes = Encoding.ASCII.GetBytes( data );

			// call base function
			bytes = SendEncap( lport, ip, port, bytes, logFunc );

			// check for error
			if( bytes == null )
				return "";

			// return string
			return Encoding.ASCII.GetString( bytes );
		}

		public static byte[] SendEncap( int lport, string ip, int port, byte[] data, LogFunc logFunc )
		{
			byte[] bytes = new byte[ data.Length + 4 ];

			// add STX and address
			bytes[ 0 ] = 0x02;
			bytes[ 1 ] = 50;
			// append command code and body
			data.CopyTo( bytes, 2 );
			// append ETX
			bytes[ bytes.Length - 2 ] = 0x03;
			// calculate checksum
			bytes[ bytes.Length - 1 ] = 0;
			for( int n = 0; n < bytes.Length - 1; n++ )
			{
				bytes[ bytes.Length - 1 ] ^= bytes[ n ];
			}

			// create endpoints
			IPEndPoint remoteEP = new IPEndPoint( IPAddress.Parse( ip ), port );

			// append message to log
			logFunc?.Invoke
			(
				new string[] { remoteEP.ToString(), Encoding.ASCII.GetString( bytes ) },
				Color.White
			);

			// update window
			Application.DoEvents();

			// send/receive
			bytes = sendEncapWorker( bytes, lport, ref remoteEP );

			// convert reply to string
			string[] reply = new string[] { remoteEP.ToString(), Encoding.ASCII.GetString( bytes ) };

			// check for valid reply
			if( ( bytes[ 0 ] == 0x06 ) || ( bytes[ 0 ] == 0x15 ) )
			{
				// calculate checksum
				byte cs = 0;
				foreach( byte b in bytes )
				{
					cs ^= b;
				}

				// log reply
				if( cs != 0 )
				{
					logFunc?.Invoke( reply, Color.LightCoral );
				}
				else if( bytes[ 0 ] == 0x15 )
				{
					logFunc?.Invoke( reply, Color.LightYellow );
				}
				else
				{
					logFunc?.Invoke( reply, Color.LightGreen );
				}
			}
			else
			{
				// log error
				logFunc?.Invoke( reply, Color.LightCoral );

				// return null
				bytes = null;
			}

			// update window
			Application.DoEvents();

			// return bytes
			return bytes;
		}

		private static byte[] sendEncapWorker( byte[] data, int lport, ref IPEndPoint remoteEP )
		{
			const int TIMEOUT = 1000;

			byte[] bytes;
			try
			{
				// create udp client
				UdpClient udp = new UdpClient( lport );

				// send command to remote ip/port
				udp.Send( data, data.Length, remoteEP );

				// wait for reply
				int n;
				for( n = 0; n < TIMEOUT; n += 10 )
				{
					if( udp.Available > 0 ) break;
					Thread.Sleep( 10 );
				}

				// check for reply
				if( udp.Available > 0 )
				{
					// read reply
					bytes = udp.Receive( ref remoteEP ); // blocks
				}
				else
				{
					bytes = Encoding.ASCII.GetBytes( "No Response" );
				}

				// close socket
				udp.Close();
			}
			catch( Exception ex )
			{
				bytes = Encoding.ASCII.GetBytes( ex.Message );
			}

			// return response
			return bytes;
		}
	}
}
