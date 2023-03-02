// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Text; 
using System.Drawing; 

public class TimeLog {

	string activity {set; get;}
	string name {set; get;}
	DateTime start = new DateTime(); 
	DateTime end = new DateTime(); 
	string elapsed {set; get;}
	
	public TimeLog() {

		Console.WriteLine("Hi, the PAC Machine is initializing...");
		Console.WriteLine("Please enter your first and last name: 'First Last'");
		name = Console.ReadLine(); 
		Console.WriteLine("Thank you, " + name + ", what will you be working on today?");
		activity = Console.ReadLine(); 
		elapsed = "nil"; 

		CheckBegin(); 
	
	}

	public void CheckBegin() {

		Question begin = new Question("Ready to begin " + activity + "? If so, enter 1."); 
		begin.AskQuestion(); 
		begin.GetAnswer(); 
		if (int.TryParse(begin.answer, out int value) && Convert.ToInt32(begin.answer) == 1) {

			this.TrackTime();

		} 		
	
		else CheckBegin(); 

	}

	public void TrackTime() {

		start = DateTime.Now; 	
		Question finished = new Question("Are you finished? Enter anything.");
		finished.AskQuestion();
		finished.GetAnswer(); 
		
		end = DateTime.Now; 

		TimeSpan difference = end - start;
		
		double totalsecs = difference.TotalSeconds;
		double mins = totalsecs / 60;
		double hours = mins / 60;

		totalsecs = Math.Truncate(totalsecs); 
		mins = Math.Truncate(mins);
		hours = Math.Truncate(hours);

		mins = mins - (hours * 60);
		totalsecs = totalsecs - (mins * 60) - (hours * 60 * 60); 

		elapsed = "Time Elapsed: " + hours + " Hours, " + mins + " Minutes, " + totalsecs + " Seconds"; 


// Create the file for data 

		string tday = start.Day.ToString();
		string tmonth = start.Month.ToString();
		string tyear = start.Year.ToString(); 

		string path = @".\Data\" + tmonth + "-" + tday + "_" + this.activity + ".txt"; 

		string log = "User: " + this.name + "\n" + "Date: " + tmonth + "-" + tday + "-" + tyear + "\n" + "Activity: " + this.activity + "\n" + elapsed; 

		File.WriteAllText(path, log);
		

		Console.WriteLine(start);
		Console.WriteLine(end); 
		Console.WriteLine(elapsed); 

	}
}

public class Message {

	public string msg {set; get;} 

	public Message() {

		this.msg = "Blank"; 	

	}

	public void SendMessage() {

		Console.WriteLine(msg); 

	}

}

public class Greeter : Message {

	public Greeter() {

		this.msg = "Hi"; 

	}

	

}

public class Question {

	string query {set; get;}
	public string answer {set; get;}
	
	public void AskQuestion() {

		Console.WriteLine("Question: " + query); 

	}

	public void GetAnswer() {

		answer = Console.ReadLine(); 

	}

	public void PrintAnswer() {

		Console.WriteLine(answer); 

	}
	
	public Question(string question) {

		query = question; 
		answer = "Blank"; 			

	}

}

public class Program {

	public static void Main() {

		TimeLog one = new TimeLog(); 

	}

}