using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HigscoreSve : MonoBehaviour {
	public InputField name;
	void Start () {
		Init ();
	}


		// Update is called once per frame
		void Update () {

		}

		const string privateCode = "4fcZoIDMO02emPvesFklzgGn_thjIN8EKfi4LNMXMcdw";
		const string publicCode = "548c04c96e51b60c740bcdec";
		const string webURL = "http://dreamlo.com/lb/";

		public Highscore[] highscoresList;

		void Init() {
		}

		public void AddNewHighscore(string username, int score) {
			Debug.Log ("Trying to add " + username + " with the score: " + score);
			StartCoroutine(UploadNewHighscore(username,score));
		}

		IEnumerator UploadNewHighscore(string username, int score) {
			WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
			Debug.Log (www);
			yield return www;

			if (string.IsNullOrEmpty(www.error))
				Debug.Log ("Upload Successful");
			else {
				Debug.Log ("Error uploading: " + www.error);
			}
		}

		public void DownloadHighscores() {
			StartCoroutine("DownloadHighscoresFromDatabase");
		}

		public void saveScore(){
			AddNewHighscore (name.text, Score.score);
			Score.score = 0;
		}

		IEnumerator DownloadHighscoresFromDatabase() {
			WWW www = new WWW(webURL + publicCode + "/pipe/");
			yield return www;

			if (string.IsNullOrEmpty(www.error))
				FormatHighscores(www.text);
			else {
				Debug.Log ("Error Downloading: " + www.error);
			}
		}

		void FormatHighscores(string textStream) {
			string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
			highscoresList = new Highscore[entries.Length];

			for (int i = 0; i <entries.Length; i ++) {
				string[] entryInfo = entries[i].Split(new char[] {'|'});
				string username = entryInfo[0];

				int score = int.Parse(entryInfo[1]);

				highscoresList[i] = new Highscore(username,score);
				Debug.Log(highscoresList[i].username + ": " + highscoresList[i].score);
			}
		}

	}
