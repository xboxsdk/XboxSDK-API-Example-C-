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

        private void button1_Click(object sender, EventArgs e)
        {
            if (apikey.Text == "" || apikey.Text == null)
            {
                MessageBox.Show("Error: I need an API Key");
                return;
            }
            
            // our api url
            String url = "http://savelab.net/v2/index.php/api/user/" + apikey.Text;

            // build our api request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

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

            // deserialize our json data into a nice JObject (thanks Newtonsoft <3)
            JObject user_info = JObject.Parse(json_data);

            listBox1.Items.Add("------------------------ JSON RESPONSE ----------------");
            listBox1.Items.Add("JSON Data: " + json_data);
            listBox1.Items.Add("------------------------ END RESPONSE ----------------");
            listBox1.Items.Add(" ");
            listBox1.Items.Add("------------------------ Formatted Data ----------------");
            listBox1.Items.Add(" ");
            listBox1.Items.Add("Username: " + user_info["user_name"]);
            listBox1.Items.Add("Email: " + user_info["user_email"]);
            listBox1.Items.Add("Alias: " + user_info["user_alias"]);

            listBox1.Items.Add(" ");
            listBox1.Items.Add(" ");

            response.Close();
            readStream.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (apikey.Text == "" || apikey.Text == null)
            {
                MessageBox.Show("Error: I need an API Key");
                return;
            }

            // our api url
            String url = "http://savelab.net/v2/index.php/api/profiles/" + apikey.Text;

            // build our api request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

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

            // deserialize our json data into a nice JObject (thanks Newtonsoft <3)
            JArray user_profiles = JArray.Parse(json_data);
            //JObject user_profiles = JObject.Parse(json_data);

            listBox1.Items.Add("------------------------ JSON RESPONSE ----------------");
            listBox1.Items.Add("JSON Data: " + json_data);
            listBox1.Items.Add("------------------------ END RESPONSE ----------------");
            listBox1.Items.Add(" ");
            listBox1.Items.Add("------------------------ Formatted Data ----------------");
            listBox1.Items.Add(" ");

            foreach (JObject profile in user_profiles)
            {
                listBox1.Items.Add("---------------- Profile [ " + profile["id"] + " ]  ----------------");
                listBox1.Items.Add("Profile Name: " + profile["profile_name"]);
                listBox1.Items.Add("Profile ID: " + profile["profile_id"]);
                listBox1.Items.Add(" ");
            }

            listBox1.Items.Add(" ");
            listBox1.Items.Add(" ");

            response.Close();
            readStream.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (apikey.Text == "" || apikey.Text == null)
            {
                MessageBox.Show("Error: I need an API Key");
                return;
            }

            // our api url
            String url = "http://savelab.net/v2/index.php/api/download/" + apikey.Text + "/" + dlid.Text;

            // build our api request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // setup some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;

            // setup credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // listbox output
            listBox1.Items.Add("Downloading Save ID: 1...");

            // get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            // read our API response
            string json_data = readStream.ReadToEnd();

            // listbox output
            listBox1.Items.Add("Save Downloaded!");

            // deserialize our json data into a nice JObject (thanks Newtonsoft <3)
            JObject user_download = JObject.Parse(json_data);

            // get our real filename
            string file_name = (string)user_download["filename"];

            // listbox output
            listBox1.Items.Add("Writing out save to: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + file_name);
            
            // get our save file data as a base64 encoded string
            byte[] fileData = Convert.FromBase64String((string)user_download["data"]);

            // write ouRRRRRR byte[] array to rrRRRRR save, says pirate pete.
            System.IO.File.WriteAllBytes( Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + file_name, fileData );

            MessageBox.Show("Finsihed!");

            listBox1.Items.Add(" ");
            listBox1.Items.Add(" ");

            response.Close();
            readStream.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + @"\api.key"))
                apikey.Text = File.ReadAllText(Environment.CurrentDirectory + @"\api.key");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.CurrentDirectory + @"\api.key", apikey.Text);
        }
    }
    
}
