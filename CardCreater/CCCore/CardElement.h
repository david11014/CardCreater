#include <iostream>
using namespace System;

namespace CCCore
{
	public ref class CardElement
	{
	public:
		int x, y;
		CardElement();
		virtual ~CardElement();
		String^ GetBackGroundPath();
		void SetBackGroundPath(String^ path);
	private:
		std::string *bg;
		
	};

	public ref class CardBackGround : CardElement
	{
	public:

		CardBackGround();
		~CardBackGround();
	};

	public ref class CardFram : CardElement
	{
	public:

		CardFram();
		~CardFram();
	
	};

	public ref class CardNum : CardElement
	{
	public:
		int num;

		CardNum();
		~CardNum();
		
	};

	public ref class CardText : CardElement
	{
	public:

		CardText();
		~CardText();
	};
}

