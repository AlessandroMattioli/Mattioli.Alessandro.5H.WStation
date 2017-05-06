using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mattioli.Alessandro._5H.WStation
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Features
        {
            public int conditions { get; set; }
        }

        private async void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync(new Uri(@"http://api.wunderground.com/api/6a5d66636582ea3b/conditions/q/IT/" + tbxCitta.Text + ".json"));
                JsonMeteo Meteo = JsonConvert.DeserializeObject<JsonMeteo>(result);
                lblNomeCitta.Content = "Citta: " + Meteo.current_observation.display_location.city.ToString();
                lblAltitudine.Content = "Altitudine: " + Meteo.current_observation.display_location.elevation.ToString() + "Mt";
                lblLatitudine.Content = "Latitudine: " + Meteo.current_observation.display_location.latitude.ToString() + "°";
                lblLongitudine.Content = "Longitudine: " + Meteo.current_observation.display_location.longitude.ToString() + "°";
                lblTemperatura.Content = "Temperatura: " +  Meteo.current_observation.temp_c.ToString() + "°C";
                lblVento.Content = "Vento: " + Meteo.current_observation.wind_kph.ToString() + "Km/h";
                lblPressione.Content = "Pressione: " + Meteo.current_observation.pressure_mb.ToString() + " Millibar";
                lblUmidita.Content = "Umidità: " + Meteo.current_observation.relative_humidity.ToString();
                if(Convert.ToInt32(Meteo.current_observation.UV)<1)
                {
                    lblUv.Content = "Raggi UV: Non presenti";
                }
                else
                {
                    lblUv.Content = "Raggi UV: " + Meteo.current_observation.UV.ToString();
                }
                imgMeteo.Source = new BitmapImage(new Uri(Meteo.current_observation.icon_url));
            }
            catch(Exception I)
            {
                MessageBox.Show("Citta non valida --> " + I.Message);    
            }
        }

        public class Response
        {
            public string version { get; set; }
            public string termsofService { get; set; }
            public Features features { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
            public string title { get; set; }
            public string link { get; set; }
        }

        public class DisplayLocation
        {
            public string full { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string state_name { get; set; }
            public string country { get; set; }
            public string country_iso3166 { get; set; }
            public string zip { get; set; }
            public string magic { get; set; }
            public string wmo { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
        }

        public class ObservationLocation
        {
            public string full { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string country_iso3166 { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
        }

        public class Estimated
        {
        }

        public class CurrentObservation
        {
            public Image image { get; set; }
            public DisplayLocation display_location { get; set; }
            public ObservationLocation observation_location { get; set; }
            public Estimated estimated { get; set; }
            public string station_id { get; set; }
            public string observation_time { get; set; }
            public string observation_time_rfc822 { get; set; }
            public string observation_epoch { get; set; }
            public string local_time_rfc822 { get; set; }
            public string local_epoch { get; set; }
            public string local_tz_short { get; set; }
            public string local_tz_long { get; set; }
            public string local_tz_offset { get; set; }
            public string weather { get; set; }
            public string temperature_string { get; set; }
            public double temp_f { get; set; }
            public double temp_c { get; set; }
            public string relative_humidity { get; set; }
            public string wind_string { get; set; }
            public string wind_dir { get; set; }
            public int wind_degrees { get; set; }
            public double wind_mph { get; set; }
            public string wind_gust_mph { get; set; }
            public double wind_kph { get; set; }
            public string wind_gust_kph { get; set; }
            public string pressure_mb { get; set; }
            public string pressure_in { get; set; }
            public string pressure_trend { get; set; }
            public string dewpoint_string { get; set; }
            public int dewpoint_f { get; set; }
            public int dewpoint_c { get; set; }
            public string heat_index_string { get; set; }
            public string heat_index_f { get; set; }
            public string heat_index_c { get; set; }
            public string windchill_string { get; set; }
            public string windchill_f { get; set; }
            public string windchill_c { get; set; }
            public string feelslike_string { get; set; }
            public string feelslike_f { get; set; }
            public string feelslike_c { get; set; }
            public string visibility_mi { get; set; }
            public string visibility_km { get; set; }
            public string solarradiation { get; set; }
            public string UV { get; set; }
            public string precip_1hr_string { get; set; }
            public string precip_1hr_in { get; set; }
            public string precip_1hr_metric { get; set; }
            public string precip_today_string { get; set; }
            public string precip_today_in { get; set; }
            public string precip_today_metric { get; set; }
            public string icon { get; set; }
            public string icon_url { get; set; }
            public string forecast_url { get; set; }
            public string history_url { get; set; }
            public string ob_url { get; set; }
            public string nowcast { get; set; }
        }

        public class JsonMeteo
        {
            public Response response { get; set; }
            public CurrentObservation current_observation { get; set; }
        }

        
    }
}
