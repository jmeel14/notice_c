namespace Notices;

using System;
using System.Collections.Generic;
using System.Text.Json;

class Notice{
	class _colours {
		private string fg; private string bg;
		public _colours(Dictionary <string, string> colsDict){
		    Console.WriteLine(JsonSerializer.Serialize(colsDict));
			fg = "\x1B[38:5:" + (colsDict["fg"] != "" ? colsDict["fg"] : "232") + "m"; 
			bg = "\x1B[48:5:" + (colsDict["bg"] != "" ? colsDict["bg"] : "251") + "m";
		}
		public string ColourCodeStr{ get { return fg + bg; } }
	}
	
	public class _labels {
		public class _label {
			private string text; private Notice._colours colours;
			public _label(Dictionary <string,string> labelDict){
			    text = labelDict["text"];
				colours = new Notice._colours(new Dictionary <string, string> (){
				    { "fg", labelDict["colourFG"] != "" ? labelDict["colourFG"] : "" },
					{ "bg", labelDict["colourBG"] != "" ? labelDict["colourBG"] : "" }
				});
			}
			public string ColourLabel { get { return colours.ColourCodeStr + text; } }
		}
		
		public _label title; public _label desc;
		public _labels(Dictionary <string, Dictionary<string, string>> labelsDict){
			title = new (labelsDict["title"]);
			desc = new (labelsDict["desc"]);
		}
	}
	
	private string _TitleText; private string _DescText;
	private _labels _Labels;
	public Notice(string ntcTitleText, string ntcDescText,
		Dictionary <string, Dictionary <string, string>> ntcLblDict)
	{
		_TitleText = ntcTitleText; _DescText = ntcDescText;
		_Labels = new (ntcLblDict);
	}
	
	public void Display(){
		List <Notice._labels._label> displayList = new List <Notice._labels._label>(){ this._Labels.title, this._Labels.desc }; 
		Console.WriteLine(displayList[0].ColourLabel + this._TitleText);
		Console.WriteLine(displayList[1].ColourLabel + this._DescText + "\x1B[0m");
	}
}

class BaseProgram{
    public static void Main(string[] args){
		Notice TestNotice = new ("Proof of concept",
			"This is a test example of how this should work. Earlier it was needlessly complicated, but now it is too simple. Much work to be done here.",
			new (){
			    { "title", new (){ { "text", "Notice: " }, { "colourFG", "232" }, { "colourBG", "251" } } },
				{ "desc", new (){ { "text", "Details: " }, { "colourFG", "232" }, { "colourBG", "243" } } }
			}
		);
		TestNotice.Display();
	}
}