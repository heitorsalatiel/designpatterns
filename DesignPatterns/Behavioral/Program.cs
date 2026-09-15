/*===== 1. Visitor : =====*/

//Example 1 : 

using Behavioral.Visitor.Example1;
using Behavioral.Visitor.Example2;

Console.WriteLine();
Console.WriteLine("1) Generic Example : ");
Console.WriteLine();

Element element1 = new ConcreteElement1();
Element element2 = new ConcreteElement2();

Visitor visitor1 = new ConcreteVisitor1();
Visitor visitor2 = new ConcreteVisitor2();

element1.Accept(visitor1);
element1.Accept(visitor2);

element2.Accept(visitor1);
element2.Accept(visitor2);

Console.WriteLine();

//Example 2 : 

List<IDocumentElement> elements =
[
    new TitleElement("The Visitor Design Pattern"),
    new SubtitleElement("Intent"),
    new ContentElement("Represent an operation to be performed on the elements of an object structure (a group of related objects). \r\nVisitor lets you define a new operation without changing the classes of the elements on which it operates."),
    new SubtitleElement("Is it cool ?"),
    new ContentElement("Yes"),
];

Console.WriteLine();
Console.WriteLine("2) Text format : ");
Console.WriteLine();

TextDocumentVisitor textDocumentVisitor = new();

foreach(var element in elements)
{
    element.Accept(textDocumentVisitor);
}

Console.WriteLine();
Console.WriteLine("3) Markdown format : ");
Console.WriteLine();

MarkdownVisitor markdownVisitor = new();

foreach (var element in elements)
{
    element.Accept(markdownVisitor);
}