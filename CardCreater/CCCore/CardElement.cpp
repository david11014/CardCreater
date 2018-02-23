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
}


CardElement::~CardElement()
{
}

String^ CCCore::CardElement::GetBackGroundPath()
{
	String^ R = gcnew String(bg->c_str());
	return R;
}

void CCCore::CardElement::SetBackGroundPath(String^ path)
{
	bg = new string;
	MarshalString(path, *bg);
}

CCCore::CardImgNum::CardImgNum()
{
}

CCCore::CardImgNum::~CardImgNum()
{
}

CCCore::CardBackground::CardBackground()
{
	
}

CCCore::CardBackground::~CardBackground()
{
	throw gcnew System::NotImplementedException();
}

CCCore::CardFram::CardFram()
{
	throw gcnew System::NotImplementedException();
}

CCCore::CardFram::~CardFram()
{
	throw gcnew System::NotImplementedException();
}

CCCore::CardText::CardText()
{
	Text = "";
	color = Color::Black;
	font = gcnew Font("", 3);
}

CCCore::CardText::~CardText()
{
	throw gcnew System::NotImplementedException();
}

String ^ CCCore::CardText::GetColorHex()
{	
	return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
}
