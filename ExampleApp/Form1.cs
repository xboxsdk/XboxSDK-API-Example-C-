using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

// =========================================================================================================================================
//                      bbbbbbbb                                                                                                          
// XXXXXXX       XXXXXXXb::::::b                                                  SSSSSSSSSSSSSSS DDDDDDDDDDDDD       KKKKKKKKK    KKKKKKK
// X:::::X       X:::::Xb::::::b                                                SS:::::::::::::::SD::::::::::::DDD    K:::::::K    K:::::K
// X:::::X       X:::::Xb::::::b                                               S:::::SSSSSS::::::SD:::::::::::::::DD  K:::::::K    K:::::K
// X::::::X     X::::::X b:::::b                                               S:::::S     SSSSSSSDDD:::::DDDDD:::::D K:::::::K   K::::::K
// XXX:::::X   X:::::XXX b:::::bbbbbbbbb       ooooooooooo xxxxxxx      xxxxxxxS:::::S              D:::::D    D:::::DKK::::::K  K:::::KKK
//    X:::::X X:::::X    b::::::::::::::bb   oo:::::::::::oox:::::x    x:::::x S:::::S              D:::::D     D:::::D K:::::K K:::::K   
//     X:::::X:::::X     b::::::::::::::::b o:::::::::::::::ox:::::x  x:::::x   S::::SSSS           D:::::D     D:::::D K::::::K:::::K    
//      X:::::::::X      b:::::bbbbb:::::::bo:::::ooooo:::::o x:::::xx:::::x     SS::::::SSSSS      D:::::D     D:::::D K:::::::::::K     
//      X:::::::::X      b:::::b    b::::::bo::::o     o::::o  x::::::::::x        SSS::::::::SS    D:::::D     D:::::D K:::::::::::K     
//     X:::::X:::::X     b:::::b     b:::::bo::::o     o::::o   x::::::::x            SSSSSS::::S   D:::::D     D:::::D K::::::K:::::K    
//    X:::::X X:::::X    b:::::b     b:::::bo::::o     o::::o   x::::::::x                 S:::::S  D:::::D     D:::::D K:::::K K:::::K   
// XXX:::::X   X:::::XXX b:::::b     b:::::bo::::o     o::::o  x::::::::::x                S:::::S  D:::::D    D:::::DKK::::::K  K:::::KKK
// X::::::X     X::::::X b:::::bbbbbb::::::bo:::::ooooo:::::o x:::::xx:::::x   SSSSSSS     S:::::SDDD:::::DDDDD:::::D K:::::::K   K::::::K
// X:::::X       X:::::X b::::::::::::::::b o:::::::::::::::ox:::::x  x:::::x  S::::::SSSSSS:::::SD:::::::::::::::DD  K:::::::K    K:::::K
// X:::::X       X:::::X b:::::::::::::::b   oo:::::::::::oox:::::x    x:::::x S:::::::::::::::SS D::::::::::::DDD    K:::::::K    K:::::K
// XXXXXXX       XXXXXXX bbbbbbbbbbbbbbbb      ooooooooooo xxxxxxx      xxxxxxx SSSSSSSSSSSSSSS   DDDDDDDDDDDDD       KKKKKKKKK    KKKKKKK
// =========================================================================================================================================
// https://xboxsdk.com & https://xboxapi.com

/**
 * In this example we used Newtonsoft's JSON Parsing libarary.
 * This can be found: http://james.newtonking.com/projects/json-net.aspx
 * Thanks to James Newton-King for this great libaray.
 */
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ExampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // on our form load read api.key file if it exists
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + @"\api.key"))
                apikey.Text = File.ReadAllText(Environment.CurrentDirectory + @"\api.key");
        }
        
        // function will get user info from our api
        private void GetUserInfo_Click(object sender, EventArgs e)
        {
            // our api uri
            string uri = "https://xboxsdk.com/api/user/" + apikey.Text;

            // query API get our api response
            JObject api_response = APIQuery(uri);

            // check to see if our API query was a success or not
            if ((bool)api_response["success"])
            {
                listBox1.Items.Add(" Username: \t" + api_response["data"]["user_name"]);
                listBox1.Items.Add(" Email: \t\t" + api_response["data"]["user_email"]);
                listBox1.Items.Add(" Alias: \t\t" + api_response["data"]["user_alias"]);
            }
            else
            {
                MessageBox.Show("Error: " + api_response["error"]);
            }
        }

        // function will get users profiles
        private void GetProfiles_Click(object sender, EventArgs e)
        {
            // our api uri
            string uri = "https://xboxsdk.com/api/profiles/" + apikey.Text;

            // query API and get response
            JObject api_response = APIQuery(uri);

            // check to see if our API query was a success
            if ((bool)api_response["success"])
            {   
                foreach (JObject profile in api_response["data"])
                {
                    listBox1.Items.Add("---------------- Profile ----------------");
                    listBox1.Items.Add("ID: \t\t" + profile["id"]); 
                    listBox1.Items.Add("Profile Name: \t" + profile["profile_name"]);
                    listBox1.Items.Add("Profile ID: \t" + profile["profile_id"]);
                    listBox1.Items.Add(" ");
                }
            }
            else
            {
                MessageBox.Show("Error: " + api_response["error"]);
            }
        }

        // function to download a save
        private void DownloadSave_Click(object sender, EventArgs e)
        {
            string uri = null;

            // our api uri
            if (MessageBox.Show("Do you want to resign this download with the Profile ID?", "Resign?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                uri = "https://xboxsdk.com/api/resign/" + apikey.Text + "/" + dlid.Text + "/" + pfid.Text;    
            else
                uri = "https://xboxsdk.com/api/download/" + apikey.Text + "/" + dlid.Text;

            // query API and get response
            JObject api_response = APIQuery(uri);

            // check to see if our API query was a success
            if ((bool)api_response["success"])
            {
                // listbox output
                listBox1.Items.Add("Downloading Save ID: " + dlid.Text);

                // get our real filename
                string file_name = (string)api_response["data"]["file_name"];

                // get our save file data as a base64 encoded string
                byte[] fileData = Convert.FromBase64String((string)api_response["data"]["file_data"]);

                // write ouRRRRRR byte[] array to rrRRRRR save, says pirate pete.
                System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + file_name, fileData);

                // output
                listBox1.Items.Add("Finished" + dlid.Text);
                listBox1.Items.Add("Writing out save to: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + file_name);
            }
            else
            {
                MessageBox.Show("Error: " + api_response["error"]);
            }
        }

        // function to save api key to api.key file
        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.CurrentDirectory + @"\api.key", apikey.Text);
        }

        // function to clear our listbox
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        // APIQuery
        // function will call XboxSDK API with the passed uri and return it's response
        // note: XboxSDK will always return from within an array and will always
        //       have the "success" key with a bool value if the API call was a success
        //       or not.
        // 
        //       If the "success" key is true "data" key will be present
        //       if false then "error" will be present with a string of the error
        public JObject APIQuery(string api_uri)
        {
            if (apikey.Text == "" || apikey.Text == null)
            {
                MessageBox.Show("Error: I need an API Key");
                return null;
            }

            // build our api request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api_uri);

            // setup some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;

            // setup credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            // read our API response
            string json_data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            // deserialize our json data into a nice JObject (thanks Newtonsoft <3)
            return JObject.Parse(json_data);
        }
    }
    
}
