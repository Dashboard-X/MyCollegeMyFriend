using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for MailBoxInfo
/// </summary>
public class MailBoxInfo
{
	public MailBoxInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected string senderUserLoginID;
    protected string receiverUserLoginID;
    protected string mailBoxSubject;
    protected string mailBoxText;

    public string SenderUserLoginID
    {
        get { return senderUserLoginID; }
        set { senderUserLoginID = value; }
    }

    public string ReceiverUserLoginID
    {
        get { return receiverUserLoginID; }
        set { receiverUserLoginID = value; }
    }

    public string MailBoxSubject
    {
        get { return mailBoxSubject; }
        set { mailBoxSubject = value; }
    }

    public string MailBoxText
    {
        get { return mailBoxText; }
        set { mailBoxText = value; }
    }
}
