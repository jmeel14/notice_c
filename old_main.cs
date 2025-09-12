namespace Notices;

using System;
using System.Text.Json;
using System.Collections.Generic;

public class _Notice {
    public class _Foundation {
        public class _Template {
            public class _Label {
                public class _Colours {
				    public class _col {
					    private string ColCode;
						public _col(string colRef, string colVal){
						    ColCode = "\x1B[" + colRef + ":5:" + colVal + "m";
						}
						public string ShowCode { get { return ColCode; } }
					}
                    private _col _fg; private _col _bg;
                    private _Colours(List<string> cols){
						_fg = new ("48", cols[0] != "" ? cols[0] : "231");
                        _bg = new ("48", cols[1] != "" ? cols[1] : "242");
                    }
					public string ColourCode { get { return _fg.ShowCode + _bg.ShowCode; } }
                }
				public class _Text {
					private _Colours _cols; private string _text;
					public _Text(_Colours colVals, string textVal){
					    _cols = colVals; _text = textVal;
					}
					public string ColourText{ get { return this._cols.ColourCode + this._text; } }
				}
				
				private _Text _LabelText;
				private _Label(_Text lblText){ _LabelText = lblText; }
				public string ColourLabel { get { return this._LabelText.ColourText; } }
            }
            private _Label _Title;
            private _Label _Desc;
            public _Template(_Label templateTitle, _Label templateDesc){
                _Title = templateTitle; _Desc = templateDesc;
            }
        }
	
		public class _DefaultText{
			private string _textVal;
			public _DefaultText(string defTxt = ""){ _textVal = defTxt; }
			public TextValue{ get { return _textVal; } }
		}
		
		private _Template _NoticeTemplate;
		private _DefaultText _TitleDefText; private _DefaultText _DescDefText;
		private _Foundation(_Template fdnTemplate,
			string titleDefText, string descDefText
		){
			_NoticeTemplate = fdnTemplate;
			if(!(titleDefText is null)){ _TitleDefText = new (titleDefText); }
			if(!(descDefText is null)){ _DescDefText = new (descDefText); }
		}
	}
	
	public class _PlainText {
		private string _BasicText;
		public _PlainText(string rawText){ _BasicText = rawText; }
		public string ReadableText{ get { return _BasicText; } }
	}
	
	private _PlainText _TitleText; private _PlainText _DescText;
	private _Foundation _NoticeFoundation;
	public _Notice(_PlainText ntcTitle, _PlainText ntcDesc, string ntcType){
		_NoticeFoundation = new _Foundation(
		    new _Foundation._Template());
		_TitleText = ntcTitle; _DescText = ntcDesc;
	}
}
	
public class NoticeDictionary {
	public Dictionary <string, _Notice> References;
	
	public void AddEntry(string ntcDictRef, _Notice ntc){
		if(!(References is null)){ References.Add(ntcDictRef, ntc); }
		else { Console.WriteLine("Warning! You have not initiated the Notices Dictionary. Your Notices will not be seen!"); }
	}
	
	public NoticeDictionary(bool useDefaults=false){
		References = new ();
		if(!useDefaults){ return; }
		AddEntry("generic",
		    new _Notice(, new ("Something deep and dramatic and scary yadda yadda yadda"), new (
			new (new (new (new (){ "97", "" }), "Notice: ")),
			new (new (new (new(){ "", "" }),"Details: "))
		)));
	}
}
		/*
		AddEntry("success", new (){
			{ "title", new (){
				{ "text", "Completed: " }, { "colourB", "40" }, { "colourF", "" }
			} },
			{ "desc", new (){
				{ "text", "Note: " }, { "colourB", "28" }, { "colourF", "" }
			} }
		});
		AddEntry("info", new (){
			{ "title", new (){
				{ "text", "Information: " }, { "colourB", "81" }, { "colourF", "18" }
			} },
			{ "desc", new (){
				{ "text", "Description: " }, { "colourB", "33" }, { "colourF", "233" }
			} }
		});
		AddEntry("warn", new (){
			{ "title", new (){
				{ "Warning: " }, { "colourB", "208" "236" }
			} },
			{ "desc", new (){
				{ "Reason: " }, { "colourB", "130" }, { "colourF", "233" }
			} }
		});
		AddEntry("error", { "Error: " }, { "colour" "124" "255" }
			} },
			{ "desc", new (){
				{ "Cause: " }, { "colourB", "52" "248" }
			} }
		});*/
/*
private string _FillSpace(string lineContent){
	private int viewWidth = Console.WindowWidth;
	private List <string> strSpaces = new ();
	for(int ltr = 0; ltr < viewWidth - lineContent.Length; ltr++){
		strSpaces.Add("\s");
	}
	return (1 + 1).ToString();
}
*/


class BaseProgram{
    public static void Main(){
        NoticeDictionary TemplatesDictionary;
        bool useProvided = true;
        Console.WriteLine("Initializing Notices. Use existing formatting? (Y/n)");
        ConsoleKeyInfo inputUseStandards = Console.ReadKey();
        if(!(inputUseProvided.Key.ToString() == "Enter" || inputUseProvided.Key.ToString().ToLower() == "y")){
            Console.WriteLine(String.Join("", new List <string> (){
                "You have chosen to not use standard template formats.",
                "Create your own format using the Notice class."
            }));
            useProvided = false;
        }
        TemplatesDictionary = new(useProvided);
		Console.WriteLine(TemplatesDictionary);
        
    }
}