/*using System;
using System.Runtime.InteropServices;
using System.Net;
namespace Ntp
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{

				ExamForNtp01 examForNtp01 = new ExamForNtp01();
				string Username = "thanhpv";
				string password = "";
				int examId = 435;
				long QuestionId = 31747;
			

				string FormatDateTime = "dd/MM/yyyy HH:mm:ss.fff";
				const string ntpServer = "time.windows.com";//default Windows time server
				IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;
				//The UDP port number assigned to NTP is 123
				IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123); //NTP uses UDP
																		   // NTP message size - 16 bytes of the digest (RFC 1305)
																		   //byte[] ntpMessage = new byte[48];
																		   //Setting the Leap Indicator, Version Number and Mode values
				*//*ntpMessage[0] = 0x1B; //LI = 00 (no warning), VN =011-> 3 (IPv4 only), Mode =011--> 3 (Client Mode)
				DateTime OriginateSendTimestamp = System.DateTime.Now; //T1
				
                //
                string response = examForNtp01.GetNtpMessage(Username, password, examId, QuestionId,ref OriginateTimeUtcTick, ref ntpMessage);

				Console.WriteLine(response);*//*

				DateTime OriginateSendTimestamp = System.DateTime.Now; //T1
				long OriginateTimeUtcTick = System.DateTime.Now.Ticks;
				byte[] ntpMessage =   { 28, 03, 00, 233, 00, 00, 00, 00,
										0, 0, 12, 160, 25, 66,   00, 00,
										225, 72, 40, 195, 105, 242, 38, 249,
										00, 00, 00, 00, 00, 00, 00, 00,
										225, 72, 40, 208, 41, 242, 12, 33,
										225, 72, 40, 208, 41, 242, 52, 101};

				
				byte Position = 32; //Received Time 
				DateTime ReceiveTimestamp = DateTimeParser(ntpMessage, Position).ToLocalTime(); //T2
				Position = 40;
				DateTime TransmitTimestamp = DateTimeParser(ntpMessage, Position).ToLocalTime(); //T3

				Position = 16;
				OriginateSendTimestamp = DateTimeParser(ntpMessage, Position).ToLocalTime(); // T1
				*//*
								DateTime OriginateReceiveTimestamp = new DateTime(OriginateTimeUtcTick); //T4

								DateTime T4 = new DateTime(2019, 10, 9, 16, 37, 29, 229);*//*
				DateTime OriginateReceiveTimestamp = new DateTime(2019, 10, 9, 16, 37, 29, 229); // T4;

				long Theta = (long)Math.Round(((ReceiveTimestamp.Ticks - OriginateSendTimestamp.Ticks)
					+ (TransmitTimestamp.Ticks - OriginateReceiveTimestamp.Ticks)) / 2.0, 0, MidpointRounding.AwayFromZero);


				DateTime FinalDateTime = OriginateReceiveTimestamp.AddTicks(Theta);
				DateTimeUtils.SetDateTime(FinalDateTime.ToUniversalTime());
				// FinalDateTime = System.DateTime.Now;
				Console.WriteLine("Originate Send Timestamp T1: " + OriginateSendTimestamp.ToString(FormatDateTime));
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("ReceiveTimestamp T2: " + ReceiveTimestamp.ToString(FormatDateTime));
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("Transmit Timestamp T3: " + TransmitTimestamp.ToString(FormatDateTime));
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("Originate Receive Time stamp T4: " + OriginateReceiveTimestamp.ToString(FormatDateTime));
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("Theta: " + Theta.ToString());
				Console.WriteLine(Environment.NewLine);
				Console.WriteLine("Final Time: " + FinalDateTime.ToString(FormatDateTime));

                *//*examForNtp01.Submit(Username, password, examId, QuestionId,
                    OriginateSendTimestamp,
                    ReceiveTimestamp,
                    TransmitTimestamp,
                    OriginateReceiveTimestamp,
                    Theta, FinalDateTime);*//*

            }
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			Console.WriteLine("\n Press any key to end...");
			Console.ReadKey();
		}
		//---------------------------------------------------------------------------
		static uint SwapEndianness(ulong x)
		{
			return (uint)(((x & 0x000000ff) << 24) +
										 ((x & 0x0000ff00) << 8) +
										 ((x & 0x00ff0000) >> 8) +
										 ((x & 0xff000000) >> 24));
		}
		//---------------------------------------------------------------------------
		static DateTime DateTimeParser(byte[] ntpData, byte Position)
		{
			DateTime RetVal = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);//**UTC** time
			try
			{
				ulong intPart = BitConverter.ToUInt32(ntpData, Position);//Get the seconds part
				ulong fractPart = BitConverter.ToUInt32(ntpData, Position + 4);//Get the seconds fraction
				//Convert From big-endian to little-endian
				intPart = SwapEndianness(intPart);
				fractPart = SwapEndianness(fractPart);
				ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
				//Max Integer  0xffffffff
				//            +         1
				//            0x100000000L
				RetVal = RetVal.AddMilliseconds((long)milliseconds);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return RetVal;
		}
	}
	//---------------------------------------------------------
	public struct SystemTime
	{
		public ushort Year;
		public ushort Month;
		public ushort DayOfWeek;
		public ushort Day;
		public ushort Hour;
		public ushort Minute;
		public ushort Second;
		public ushort Millisecond;
	};
	public class DateTimeUtils
	{
		[DllImport("kernel32.dll")]
		private extern static void GetSystemTime(ref SystemTime lpSystemTime);
		[DllImport("kernel32.dll")]
		private extern static uint SetSystemTime(ref SystemTime lpSystemTime);
		//---------------------------------------------------------------------------
		public static void SetDateTime(DateTime mDateTime)
		{
			try
			{
				SystemTime systime = new SystemTime();
				systime.Year = (ushort)mDateTime.Year;
				systime.Month = (ushort)mDateTime.Month;
				systime.DayOfWeek = (ushort)mDateTime.DayOfWeek;
				systime.Day = (ushort)mDateTime.Day;
				systime.Hour = (ushort)mDateTime.Hour;
				systime.Minute = (ushort)mDateTime.Minute;
				systime.Second = (ushort)mDateTime.Second;
				systime.Millisecond = (ushort)mDateTime.Millisecond;
				SetSystemTime(ref systime);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
*/