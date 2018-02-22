#include <iostream>
using namespace System;
using namespace System::Drawing;

namespace CCCore
{
	public ref class CardElement
	{
	public:
		int x, y, layer;

		CardElement();
		virtual ~CardElement();
		String^ GetBackGroundPath();
		void SetBackGroundPath(String^ path);
	private:
		std::string *bg;
		
	};

	public ref class CardBackground : CardElement
	{
	public:
		CardBackground();
		~CardBackground();
	};

	public ref class CardFram : CardElement
	{
	public:

		CardFram();
		~CardFram();
	
	};

	public ref class CardImgNum : CardElement
	{
	public:
		int num;
		
		CardImgNum();
		~CardImgNum();
		
	};

	public ref class CardText : CardElement
	{
	public:
		String^ Text;
		Color color;
		Font font;
		CardText();
		~CardText();
	};
}

