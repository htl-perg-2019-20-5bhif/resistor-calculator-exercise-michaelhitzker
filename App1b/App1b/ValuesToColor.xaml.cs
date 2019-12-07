using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App1b
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ValuesToColor : ContentPage
    {

        private ColorValue FirstColorValue;
        public ColorValue FirstColor
        {
            get => FirstColorValue;
            set
            {
                FirstColorValue = value;
                OnPropertyChanged(nameof(FirstColor));
            }
        }


        private ColorValue SecondColorValue;
        public ColorValue SecondColor
        {
            get => SecondColorValue;
            set
            {
                SecondColorValue = value;
                OnPropertyChanged(nameof(SecondColor));
            }
        }


        private string ErrorValue;
        public string Error
        {
            get => ErrorValue;
            set
            {
                ErrorValue = value;
                OnPropertyChanged(nameof(Error));
            }
        }


        private ColorValue ThirdColorValue;
        public ColorValue ThirdColor
        {
            get => ThirdColorValue;
            set
            {
                ThirdColorValue = value;
                OnPropertyChanged(nameof(ThirdColor));
            }
        }

        public ValuesToColor()
        {
            Lists = new ColorLists();
            InitializeComponent();
            BindingContext = this;
        }

        public ColorLists Lists { get; set; }

        public long Value { get; set; }
        private void GetColors(object sender, EventArgs e)
        {
            long curValue = Value;
            int count = 0;
            //Count how many zeros are in our Value
            while (curValue / 100 > 0)
            {
                count++;

                if (curValue % 10 != 0)
                {
                    Error = $"Error while parsing values!";
                    return;
                }
                curValue /= 10;
            }
            ColorValue first = null;
            ColorValue second = null;
            ColorValue third = null;
            long secondVal = curValue % 10;
            long firstVal = curValue / 10;

            if (firstVal <= Lists.FirstBandList.Count)
            {
                first = Lists.FirstBandList[(int)firstVal - 1];
            }
            second = Lists.SecondBandList[(int)secondVal];
            if (count < Lists.ThirdBandList.Count)
            {
                third = Lists.ThirdBandList[count];
            }

            if (first != null && second != null && third != null)
            {
                FirstColor = first;
                SecondColor = second;
                ThirdColor = third;
                Error = "";
            }
            else
            {
                Error = "Error while parsing values!";
                //Display Error
            }

        }
    }
}