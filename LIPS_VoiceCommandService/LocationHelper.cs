using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace LIPS.VoiceCommands
{
    class LocationHelper
    {
        private async static Task<string> GetMyLocationAddress()
        {
            var address = await GetAddress();
            return $"{address.addressLine}, {address.adminDistrict2}";

        }

        private static T Deserialize<T>(string json)
        {
            var instance = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(instance.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        public async static Task<Address> GetAddress()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://svdhlocationapi.azurewebsites.net/api/location");

            if (response.IsSuccessStatusCode)
            {
                var jsonBingLocation = await response.Content.ReadAsStringAsync();
                var address = Deserialize<Address>(jsonBingLocation);
                return address;
            }
            return new Address();
        }

        public async static Task<ParkingStatus> GetParkingPlaces()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("http://mindparkfacilityapi.azurewebsites.net/api/Parking/30");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var places = await response.Content.ReadAsStringAsync();
                    var pStatus = Deserialize<ParkingStatus>(places);
                    return pStatus;
                }
                catch(Exception ex)
                {
                    return new ParkingStatus();
                }
            }
            return new ParkingStatus();
        }
    }

}
