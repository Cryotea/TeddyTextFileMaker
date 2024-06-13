// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Spectre.Console;

AnsiConsole.Write(
    new FigletText("Textfile writer")
        .Color(Color.Purple)
    );
AnsiConsole.MarkupLine("[purple]Where do you want to create a Textfile[/]?");
bool pathIsValid = false;
string path = null;
while (!pathIsValid)
{  
    path = AnsiConsole.Prompt(
        new TextPrompt<string>("[purple]FilePath: [/]")
            .PromptStyle("grey"));
    if (Directory.Exists(path))
    {
        pathIsValid = true;
    }
    else
    {
        AnsiConsole.MarkupLine($"{path} [red]is not a valid Path![/]");
    }
}

string fileName;

fileName = AnsiConsole.Prompt(
    new TextPrompt<string>("[purple]How do you want to name the file?[/]")
        .PromptStyle ("grey"));

string fullpath = path + "/" + fileName + ".txt";

string text = AnsiConsole.Prompt(
    new TextPrompt<string>("[purple]what do you want to write in the file?[/]")
        .PromptStyle ("grey"));

using (StreamWriter sw = File.CreateText(fullpath))
{
    sw.WriteLine(text);
}

Process.Start("explorer.exe" , path);
