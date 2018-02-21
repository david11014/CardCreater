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

CardElement::CardElement()
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

CCCore::CardNum::CardNum()
{
}

CCCore::CardNum::~CardNum()
{
}

CCCore::CardBackGround::CardBackGround()
{
	throw gcnew System::NotImplementedException();
}

CCCore::CardBackGround::~CardBackGround()
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
	throw gcnew System::NotImplementedException();
}

CCCore::CardText::~CardText()
{
	throw gcnew System::NotImplementedException();
}
