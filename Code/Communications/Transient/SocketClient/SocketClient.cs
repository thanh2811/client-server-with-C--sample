using System;
using System.Net;
using System.Net.Sockets;
using System.Text; 

namespace SocketClient
{
	class SocketClient
	{
		static void Main(string[] args)
		{
			int ServerPort = ConfigApp.ServerPort;
			string ServerIp = ConfigApp.ServerIp;
			byte[] bytes = new byte[1024];
			try
			{
				// Tạo điểm kết cuối trên máy chủ
				IPAddress RemoteIp = IPAddress.Parse("192.168.100.7");
				IPEndPoint remoteEP = new IPEndPoint(RemoteIp, ServerPort);
				// Tạo Socket sử dụng giao thức TCP.    
				Socket sender = new Socket(RemoteIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				try
				{
					// Kết nối đến điểm cuối máy chủ  
					sender.Connect(remoteEP);
					Console.WriteLine("Socket connected to " + sender.RemoteEndPoint.ToString());
                    while (true)
                    {
						Console.Write("Enter message: ");
						string msg_send = Console.ReadLine();
						byte[] msg = Encoding.ASCII.GetBytes(msg_send+"<EOF>");
						// Gửi thông điệp qua Socket.    
						int bytesSent = sender.Send(msg);
						   // Nhận thông điệp phản hồi từ điểm cuối máy chủ. 
						int bytesRec = sender.Receive(bytes);
						Console.WriteLine("Echoed from " + sender.RemoteEndPoint.ToString() + " ==> " + Encoding.ASCII.GetString(bytes, 0, bytesRec));
					}
					// Đóng socket.    
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();
				}
				catch (ArgumentNullException ane)
				{
					Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
				}
				catch (SocketException se)
				{
					Console.WriteLine("SocketException : {0}", se.ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine("Unexpected exception : {0}", e.ToString());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			Console.WriteLine("\n Press any key to end...");
			Console.ReadKey();
		}
	}
}
