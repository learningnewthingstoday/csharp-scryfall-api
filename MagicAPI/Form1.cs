using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using static MagicAPI.Models;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace MagicAPI
{
	public partial class Form1 : Form
	{
		static HttpClient client = new HttpClient();
		public Dictionary<string, PictureBox> pictureBoxes;
		public string clickedPicture = "";
		public PictureBox clickedBox;
		public string fPath;
		public Dictionary<string, Card> cardCache = new Dictionary<string, Card>();
		public string url = "https://api.scryfall.com/cards/random";


		public Form1()
		{

			InitializeComponent();
			pictureBoxes = new Dictionary<string, PictureBox>();
			pictureBoxes.Add("pictureBox1", pictureBox1);
			pictureBoxes.Add("pictureBox2", pictureBox2);
			pictureBoxes.Add("pictureBox3", pictureBox3);
			pictureBoxes.Add("pictureBox4", pictureBox4);
			pictureBoxes.Add("pictureBox5", pictureBox5);
			pictureBoxes.Add("pictureBox6", pictureBox6);
			pictureBoxes.Add("pictureBox7", pictureBox7);
			label1.Visible = false;
			label2.Visible = false;
			label3.Visible = false;
			textBox1.Visible = false;
			textBox2.Visible = false;
			richTextBox1.Visible = false;

			// Try to create the directory.
			dw("Creating temporary directory if none exists.");
			DirectoryInfo di = Directory.CreateDirectory("tmp");
			Debug.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime("tmp"));
			fPath = $"{Directory.GetCurrentDirectory()}\\tmp\\";
		}

		async Task<Card> GetCardAsync(string path)
		{
			Card card = null;
			dw("Attempting to GET card from ScryfallAPI 'Random' endpoint.");
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				dw("received success status code");
				card = await response.Content.ReadAsAsync<Card>();
				Task.WaitAll();
				if (card.ImageUris is null)
				{
					dw("card.ImageUris is null, recurring method.");
					return await GetCardAsync(path);
				}
				if (cardCache.ContainsKey(card.OracleId))
				{
					dw("card already exists, recurring method.");
					return await GetCardAsync(path);
				}
				dw("card is valid. returning card.");
				return card;
			}
			dw("Received failure code. recurring method.");
			return await GetCardAsync(path);
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			foreach (var pb in pictureBoxes)
			{
				pb.Value.ImageLocation = null;

				while (pb.Value.ImageLocation is null)
				{
					Card card = await GetCardAsync(url);

					cacheImage(card.ImageUris.Normal, card.OracleId);

					card.imageSrc = $"{Directory.GetCurrentDirectory()}\\tmp\\{card.OracleId}.png";
					card.pictureBoxName = pb.Value.Name;
					cacheCard(pb.Value.Name, card);
					pb.Value.ImageLocation = card.imageSrc;
				}
			}
		}

		private void pictureBox_MouseHover(object sender, EventArgs e)
		{
			PictureBox pb = sender as PictureBox;
			if (pb != null)
			{
				pictureBox8.ImageLocation = pb.ImageLocation;
			}
		}

		private void pictureBox_HoverOff(object sender, EventArgs e)
		{
			PictureBox pb = sender as PictureBox;
			pictureBox8.ImageLocation = null;
			Card cardPick = cardCache.GetValueOrDefault(pb.Name);
			textBox1.Visible = false;
			textBox2.Visible = false;
			richTextBox1.Visible = false;
			label1.Visible = false;
			label2.Visible = false;
			label3.Visible = false;
			textBox1.Text = "";
			textBox2.Text = "";
			richTextBox1.Text = "";
		}

		private void pictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			PictureBox pb = sender as PictureBox;
			
			
			if (clickedPicture == "")
			{
				dw("clickedPicture is blank");
				clickedPicture = pb.Name;
				selectPictureBox(pb);
				clickedBox = pb;
			}
			else if (clickedPicture == pb.Name)
				{
					dw("clickedPicture == pb.Name");
					unselectPictureBox(pb);
					clickedPicture = "";
					//clickedBox = null;
				}
				else if (clickedPicture != pb.Name)
				{
					dw("clickedPicture is not equal to pb.Name");
					dw("unselecting clickedbox");
					unselectPictureBox(clickedBox);
					clickedPicture = pb.Name;
					clickedBox = pb;
					selectPictureBox(pb);


				}
			


		}

		private void unselectPictureBox(PictureBox pb)
		{
			foreach (var VARIABLE in pictureBoxes)
			{
				VARIABLE.Value.MouseHover += pictureBox_MouseHover;
				VARIABLE.Value.MouseLeave += pictureBox_HoverOff;
			}

			pb.BorderStyle = BorderStyle.None;
			pb.Width = 200;
			pb.Height = 300;
			pb.Left += 15;
			pb.Top += 40;
			//clickedBox = null;
		}

		private void selectPictureBox(PictureBox pb)
		{
			foreach (var VARIABLE in pictureBoxes)
			{
				VARIABLE.Value.MouseHover -= pictureBox_MouseHover;
				VARIABLE.Value.MouseLeave -= pictureBox_HoverOff;
			}

			pb.BorderStyle = BorderStyle.Fixed3D;
			pb.Width = 230;
			pb.Height = 330;
			pb.Left -= 15;
			pb.Top -= 40;
			pictureBox8.ImageLocation = pb.ImageLocation;
			Card cardPick = cardCache.GetValueOrDefault(pb.Name);
			textBox1.Visible = true;
			textBox2.Visible = true;
			richTextBox1.Visible = true;
			label1.Visible = true;
			label2.Visible = true;
			label3.Visible = true;
			textBox1.Text = cardPick.Name;
			textBox2.Text = cardPick.ManaCost;
			richTextBox1.Text = cardPick.OracleText;
		}

		public void cacheImage(string url, string name)
		{
			using (WebClient webClient = new WebClient())
			{
				byte[] data = webClient.DownloadData(url);

				using (MemoryStream mem = new MemoryStream(data))
				{
					using (var yourImage = Image.FromStream(mem))
					{
						string fPName = $"{fPath}{name}.png";
						// If you want it as Png
						yourImage.Save(fPName, ImageFormat.Png);
					}
				}

			}
		}

		private void cacheCard(string pbName, Card card)
		{
			cardCache.Add(card.pictureBoxName, card);
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			clearTempFiles($"{Directory.GetCurrentDirectory()}\\tmp\\");
		}

		private void clearTempFiles(string targetDirectory)
		{
			string[] fileEntries = Directory.GetFiles(targetDirectory);
			foreach (string fileName in fileEntries)
			{
				File.Delete(fileName);
			}

		}

		public void dw(string message)
		{
			Debug.WriteLine(message);
		}
	}
}