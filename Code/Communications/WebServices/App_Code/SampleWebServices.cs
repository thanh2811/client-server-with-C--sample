using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
[WebService(Namespace = "http://wwww.hocvienmang.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SampleWebServices : System.Web.Services.WebService
{
	public SampleWebServices()
	{
		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}
	[WebMethod]
	public string Hello(string UserName)
	{
		string RetVal = "";
		try
		{
			if (string.IsNullOrEmpty(UserName))
			{
				RetVal = "Empty UserName";
			}
			else
			{
				RetVal = "Hello " + UserName;
			}
		}
		catch (Exception ex)
		{
			RetVal = ex.Message;
		}
		return RetVal;
	}
  //-------------------------------------------------------------
	[WebMethod]
	public DateTime GetLocalDateTime()
	{
		return System.DateTime.Now;
	}
	//-------------------------------------------------------------
	[WebMethod]
	public long GetLocalDateTimeTicks()
	{
		return System.DateTime.Now.Ticks;
	}
	//-------------------------------------------------------------
	[WebMethod]
	public DateTime GetUtcDateTime()
	{
		return System.DateTime.Now.ToUniversalTime();
	}
	//-------------------------------------------------------------
	[WebMethod]
	public long GetUtcDateTimeTicks()
	{
		return System.DateTime.Now.ToUniversalTime().Ticks;
	}
	//-------------------------------------------------------------
	[WebMethod]
	public long GetLocalDiffernceTicks(long ClientLocalDateTimeTicks)
	{
		return ClientLocalDateTimeTicks - System.DateTime.Now.Ticks;
	}
	//-------------------------------------------------------------
	[WebMethod]
	public long GetUtcDiffernceTicks(long ClientUtcDateTimeTicks)
	{
		return ClientUtcDateTimeTicks - System.DateTime.Now.ToUniversalTime().Ticks;
	}
	//-------------------------------------------------------------
	[WebMethod]
	public DateTime GetLocalDateTimeAndDiffernceTicks(long ClientLocalDateTimeTicks, ref long DiffernceTicks)
	{
		DateTime RetVal = System.DateTime.Now;
		DiffernceTicks = ClientLocalDateTimeTicks-RetVal.Ticks;
		return RetVal;
	}
	//-------------------------------------------------------------
	[WebMethod]
	public DateTime GetUtcDateTimeAndDiffernceTicks(long ClientUtcDateTimeTicks, ref long DiffernceTicks)
	{
		DateTime RetVal = System.DateTime.Now.ToUniversalTime();
		DiffernceTicks = ClientUtcDateTimeTicks - RetVal.Ticks;
		return RetVal;
	}
}
