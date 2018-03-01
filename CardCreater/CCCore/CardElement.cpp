#include "CardElement.h"
#include <string> 
#include <iostream> 
using namespace CCCore;
using namespace System;
using namespace std;

void MarshalString(String ^ s, string& os) {
	using namespace Runtime::InteropServices;
	const char* chars =
		(const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
	os = chars;
	Marshal::FreeHGlobal(IntPtr((void*)chars));
}

CardElement::CardElement():x(0),y(0),layer(0)
{
	bgPath = gcnew String("");
}

CCCore::CardElement::CardElement(CardElement % source) :x(source.x), y(source.y), layer(source.layer)
{
	CardElement();
	bgPath = gcnew String(source.bgPath->ToString());
}

CardElement::~CardElement()
{
	delete bgPath;
}

String^ CCCore::CardElement::GetBackGroundPath()
{	
	return bgPath;
}

void CCCore::CardElement::SetBackGroundPath(String^ path)
{
	bgPath = path;
}

/**CardBackground**/
CCCore::CardBackground::CardBackground()
{	
	type =0;
}

CCCore::CardBackground::CardBackground(CardBackground % source) :CardElement(source)
{	
	type =0;
}

CCCore::CardBackground::~CardBackground()
{	
}

/**CardFram**/
CCCore::CardFram::CardFram()
{
	type =1;
}

CCCore::CardFram::CardFram(CardFram % source) :CardElement(source)
{
	type = 1;
}

CCCore::CardFram::~CardFram()
{
}

/**CardImage**/
CCCore::CardImage::CardImage()
{
	type =2;
}

CCCore::CardImage::CardImage(CardImage % source) :CardElement(source)
{
	type = 2;
}

CCCore::CardImage::~CardImage()
{
	
}

/**CardImgNum**/
CCCore::CardImgNum::CardImgNum()
{
	type = 3;
}

CCCore::CardImgNum::CardImgNum(CardImgNum % source) :CardElement(source), num(source.num)
{
	type = 3;
}

CCCore::CardImgNum::~CardImgNum()
{
}

/**CardText**/
CCCore::CardText::CardText()
{
	Text = "";
	color = Color::Black;
	font = gcnew Font("", 3);
	type =4;
}

CCCore::CardText::CardText(CardText % source) :CardElement(source)
{
	
	Text = gcnew String(source.Text->ToString());
	font = gcnew Font(source.font, source.font->Style);
	type = 4;
}

CCCore::CardText::~CardText()
{
	delete Text;
	delete font;
}

String ^ CCCore::CardText::GetColorHex()
{	
	return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
}

String ^ CCCore::CardText::GetText()
{
	return Text;
}

void CCCore::CardText::SetText(String^ s)
{
	this->Text = String::Copy(s);
}
