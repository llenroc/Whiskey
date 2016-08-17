using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Whiskey.Annotations;
using Whiskey.Model;
using Xamarin.Forms;

namespace Whiskey.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Internal backing field for IsBusy
        /// </summary>
        private bool _isBusy;

        /// <summary>
        /// IsBusy property can be used to show status on UI while performing long taks like web service calls.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ObservableCollections used to hold quotes and it helps to update the UI whenever there is any change in data
        /// </summary>
        public ObservableCollection<QuotesModel> QuotesCollection { get; set; }

        public HomeViewModel()
        {
            QuotesCollection = new ObservableCollection<QuotesModel>();
        }

        /// <summary>
        /// On the main screen, this property will be used to display one random quote.
        /// </summary>
        public QuotesModel CurrentQuote
        {
            get
            {

                var rnd = new Random().Next(1, 10);
                Task.WaitAny(Task.Run(async () => { await GetQuotes(); }));
                return QuotesCollection[rnd];
            }
        }

        /// <summary>
        /// This async method will fetch JSON (text) file stored in DropBox shared folder and parse it to QuotesModel. 
        /// After parsing these quotes will be added to observable collection.
        /// </summary>
        /// <returns></returns>
        async Task GetQuotes()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;
                using (var client = new HttpClient())
                {
                    //grab json from server
                    var json = await client.GetStringAsync("https://www.dropbox.com/s/4o74hgxgkul0i05/Quotes.json?dl=1");
                    var items = JsonConvert.DeserializeObject<List<QuotesModel>>(json);
                    QuotesCollection.Clear();
                    foreach (var item in items)
                        QuotesCollection.Add(item);
                }

            }
            catch (Exception ex)
            {
                error = ex;
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }
            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }



        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
