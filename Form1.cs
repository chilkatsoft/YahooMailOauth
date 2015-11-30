using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YahooMailOauth1
    {
    public partial class Form1 : Form
	{
	// Create your YDN app at https://developer.yahoo.com/apps/create/
	// Make sure to give full access to the Mail API.

	//Client ID (Consumer Key)
	private string ConsumerKey = "Set this to your base64 consumer key.";

	//Client Secret (Consumer Secret)
	private string ConsumerSecret = "Set this to your hex consumer secret.";

	private string ChilkatUnlockCode = "Your Chilkat unlock code or anything for an automatic 30-day trial.";

	private string YahooMailPassword = "Your Yahoo Mail Password";
	private string YahooMailUsername = "Your Yahoo Mail username/email address";


	private string OAuthToken = "To be generated in Step1";
	private string OAuthTokenSecret = "To be generated in Step1";

	private string OAuthAccessToken = "To be generated in Step3";
	private string OAuthAccessTokenSecret = "To be generated in Step3";


	public Form1()
	    {
	    InitializeComponent();
	    }

	private void Form1_Load(object sender, EventArgs e)
	    {
	    // Unlock the Chilkat functionality.  
	    // This is an automatic 30-day trial, but requires a purchased license to use indefinitely.
	    Chilkat.Global global = new Chilkat.Global();
	    bool success = global.UnlockBundle(ChilkatUnlockCode);
	    if (!success)
		{
		textBox1.Text = "Failed to unlock Chilkat.";
		return;
		}
	    }


	// Get the request token and verifier.
	private void button1_Click(object sender, EventArgs e)
	    {
	    Chilkat.OAuth1 oauth = new Chilkat.OAuth1();

	    oauth.GenNonce(16);
	    oauth.GenTimestamp();

	    // The 1st step is to get a request token by sending an HTTP GET like this:
	    oauth.OauthVersion = "1.0";
	    oauth.OauthMethod = "GET";
	    oauth.OauthUrl = "https://api.login.yahoo.com/oauth/v2/get_request_token";
	    oauth.ConsumerKey = ConsumerKey;
	    oauth.ConsumerSecret = ConsumerSecret;
	    oauth.SignatureMethod = "HMAC-SHA1";
	    oauth.AddParam("oauth_callback", "oob");

	    // Generate the OAuth1 signature and URL.
	    bool success = oauth.Generate();
	    if (success != true) {
		textBox1.Text = oauth.LastErrorText;
		return;
	    }

	    // Properties set by the Generate method:
	    //textBox1.Text = "BaseString: " + oauth.BaseString + "\r\n" +
	    //    "EncodedSignature : " + oauth.EncodedSignature + "\r\n" +
	    //    "HmacKey : " + oauth.HmacKey + "\r\n" +
	    //    "GeneratedUrl : " + oauth.GeneratedUrl + "\r\n" +
	    //    "QueryString : " + oauth.QueryString + "\r\n" +
	    //    "Signature  : " + oauth.Signature + "\r\n" +
	    //    "AuthorizationHeader  : " + oauth.AuthorizationHeader + "\r\n"
	    //    ;

	    string requestTokenUrl = oauth.GeneratedUrl + "&oauth_signature=" + oauth.EncodedSignature;
	    
	    Chilkat.Http http = new Chilkat.Http();
	    
	    // Get the request token...
	    Chilkat.HttpResponse resp = http.QuickGetObj(requestTokenUrl);
	    if (resp == null) {
		textBox1.Text = http.LastErrorText;
		return;
		}

	    // Get User Authorization -- get a request verifier interactively via the embedded web browser:
	    string encodedResponseParams = resp.BodyStr;
	    OAuthToken = resp.UrlEncParamValue(encodedResponseParams, "oauth_token");
	    OAuthTokenSecret = resp.UrlEncParamValue(encodedResponseParams, "oauth_token_secret");
	    string userAuthUrl = "https://api.login.yahoo.com/oauth/v2/request_auth?oauth_token=" + OAuthToken;

	    webBrowser1.Navigate(userAuthUrl);

	    return;
	    }

	// Exchange the Request Token and OAuth Verifier for an Access Token
	private void button2_Click(object sender, EventArgs e)
	    {
	    Chilkat.OAuth1 oauth = new Chilkat.OAuth1();

	    oauth.GenNonce(16);
	    oauth.GenTimestamp();

	    // The 1st step is to get a request token by sending an HTTP GET like this:
	    oauth.OauthVersion = "1.0";
	    oauth.OauthMethod = "GET";
	    oauth.OauthUrl = "https://api.login.yahoo.com/oauth/v2/get_token";
	    oauth.ConsumerKey = ConsumerKey;
	    oauth.ConsumerSecret = ConsumerSecret;
	    oauth.Token = OAuthToken;
	    oauth.TokenSecret = OAuthTokenSecret;
	    oauth.SignatureMethod = "HMAC-SHA1";
	    oauth.AddParam("oauth_verifier", txtVerifier.Text);

	    // Generate the OAuth1 signature and URL.
	    bool success = oauth.Generate();
	    if (success != true)
		{
		textBox1.Text = oauth.LastErrorText;
		return;
		}

	    string getAccessTokenUrl = oauth.GeneratedUrl + "&oauth_signature=" + oauth.EncodedSignature;

	    Chilkat.Http http = new Chilkat.Http();

	    // Get the request token...
	    Chilkat.HttpResponse resp = http.QuickGetObj(getAccessTokenUrl);
	    if (resp == null)
		{
		textBox1.Text = http.LastErrorText;
		return;
		}

	    // Get the access token.  
	    string encodedResponseParams = resp.BodyStr;
	    OAuthAccessToken = resp.UrlEncParamValue(encodedResponseParams, "oauth_token");
	    OAuthAccessTokenSecret = resp.UrlEncParamValue(encodedResponseParams, "oauth_token_secret");

	    textBox1.Text = "success!\n";

	    return;
	    }

	// Step 4: Can we use the Access Token with IMAP?
	// This does not work.  We don't know how to use an OAuth1 access token
	// with the IMAP protocol.  We don't know how to obtain (via Yahoo) an OAuth2
	// access token for the IMAP XOAUTH2 authentication method.
	private void button3_Click(object sender, EventArgs e)
	    {
	    Chilkat.Imap imap = new Chilkat.Imap();

	    imap.KeepSessionLog = true;

	    //  Connect to they Yahoo! IMAP server.
	    imap.Port = 993;
	    imap.Ssl = true;
	    bool success = imap.Connect("imap.mail.yahoo.com");
	    if (success != true)
		{
		textBox1.Text += "\r\n" + imap.LastErrorText;
		textBox1.Text += "\r\n" + imap.SessionLog;
		return;
		}

	    //  Send the non-standard ID command...
	    string rawResponse;
	    rawResponse = imap.SendRawCommand("ID (\"GUID\" \"1\")");
	    if (rawResponse == null)
		{
		textBox1.Text += "\r\n" + imap.LastErrorText;
		textBox1.Text += "\r\n" + imap.SessionLog;
		return;
		}

	    //rawResponse = imap.SendRawCommand("AUTHENTICATE XOAUTH2 " + OAuthAccessToken);
	    rawResponse = imap.SendRawCommand("AUTHENTICATE OAUTHBEARER " + OAuthAccessToken);
	    if (rawResponse == null)
		{
		textBox1.Text += "\r\n" + imap.LastErrorText;
		textBox1.Text += "\r\n" + imap.SessionLog;
		return;
		}
	    textBox1.Text += "\r\n" + imap.LastErrorText;
	    textBox1.Text += "\r\n" + imap.SessionLog;

	    //  Login
	    //success = imap.Login(YahooMailUsername, YahooMailPassword);
	    //if (success != true)
	    //    {
	    //    textBox1.Text = imap.LastErrorText;
	    //    return;
	    //    }

	    //  Select an IMAP mailbox
	    success = imap.SelectMailbox("Inbox");
	    if (success != true)
		{
		textBox1.Text += "\r\n" + imap.LastErrorText;
		return;
		}

	    //  Continue with whatever you wish to do...
	    //  (see other examples..)

	    //  Disconnect from the IMAP server.
	    imap.Disconnect();

	    textBox1.Text += "\r\nLogin Success!";

	    }
	}
    }
