#include <iostream>
using namespace System;
using namespace System::Drawing;

namespace CCCore
{
#define TYPE_NUM 5
	public ref class CardElement
	{
	public:
		int x, y, layer;
		int type;
		
		CardElement();
		CardElement(CardElement %source);
		~CardElement();
		String^ GetBackGroundPath();
		void SetBackGroundPath(String^ path);
	private:
		std::string *bg;
		std::string *typeName;		
	};

	public ref class CardBackground : CardElement
	{
	public:
		CardBackground();
		CardBackground(CardBackground %source);
		~CardBackground();
	};

	public ref class CardFram : CardElement
	{
	public:

		CardFram();
		CardFram(CardFram %source);
		~CardFram();	
	};

	public ref class CardImage : CardElement
	{
	public:
		CardImage();
		CardImage(CardImage %source);
		~CardImage();
	};

	public ref class CardImgNum : CardElement
	{
	public:
		int num;
		
		CardImgNum();
		CardImgNum(CardImgNum %source);
		~CardImgNum();
		
	};

	public ref class CardText : CardElement
	{
	public:
		String^ Text;
		Font^ font;
		Color color;
		
		CardText();
		CardText(CardText %source);
		~CardText();

		String^ GetColorHex();
	};
}

