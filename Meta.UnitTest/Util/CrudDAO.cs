//-----------------------------------------------------------------------
// <copyright file="CrudDAO.cs" company="Meta">
//     Copyright (c) Meta All rights reserved.
// </copyright>
// <author> Ricardo Carneiro</author>
//-----------------------------------------------------------------------

namespace Meta.UnitTest.Util
{
        using RestSharp;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;

        /// <summary>
        /// Classe  CrudDAO: Fabrica de geração DAO REST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class CrudDAO<T>
        {
            /// <summary>
            /// Método atualizar rest - PUT
            /// </summary>
            /// <param name="id">Identifcador do objeto</param>
            /// <param name="objeto">Passar o tipo de objeto </param>
            /// <param name="controller">Passar o nome do controller em String</param>
            public void Update(int id, T objeto, string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                var request = new RestRequest(controller + @"/" + id, Method.PUT);
                request.AddJsonBody(objeto);
                client.Execute(request);


            }

            /// <summary>
            ///  Método excluir rest - DELETE
            /// </summary>
            /// <param name="id">Identifcador do objeto</param>
            /// <param name="controller">Passar o nome do controller em String</param>
            public void Delete(int id, string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                var request = new RestRequest(controller + @"/" + id, Method.DELETE);
                client.Execute(request);
            }
            /// <summary>
            ///  Método Inserir rest - POST
            /// </summary>
            /// <param name="objeto">Passar o tipo de objeto </param>
            /// <param name="controller">Passar o nome do controller em String</param>
            public void Create(T objeto, string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                var request = new RestRequest(controller + @"/", Method.POST);
                request.AddJsonBody(objeto);
                client.Execute(request);
            }

            /// <summary>
            ///  Método Consultar rest - GET
            /// </summary>
            /// <param name="controller">Passar o nome do controller em String</param>
            /// <returns>Listagem do Objeto</returns>
            public IEnumerable<T> Get(string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/", Method.GET);
                var response = client.Execute<List<T>>(request);
                IEnumerable<T> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content);
                return obj;
            }

            public IQueryable<T> GetIQueryable(string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/", Method.GET);
                var response = client.Execute<IQueryable<T>>(request);
                IQueryable<T> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<IQueryable<T>>(response.Content);
                return obj;
            }
            public int GetNextId(string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/", Method.GET);
                var response = client.Execute<List<T>>(request);
                int obj = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(response.Content);
                return obj;
            }
            /// <summary>            ((RestSharp.RestResponseBase)response).Content
            ///  Método Consultar por ID  rest - GET
            /// </summary>
            /// <param name="id">Identifcador do objeto</param>
            /// <param name="controller">Passar o nome do controller em String</param>
            /// <returns>Objeto</returns>
            public T GetById(int id, string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/" + id, Method.GET);
                var response = client.Execute<T>(request);
                T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);

                return obj;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public bool GetByIdExist(int id, string controller)
        {
            var client = new RestClient(Constantes.URL_API);
            RestRequest request = new RestRequest(controller + @"/" + id, Method.GET);
            var response = client.Execute<T>(request);
            T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);

            if (obj != null)
            {

                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public T GetByStrID(string strID, string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/" + strID, Method.GET);
                var response = client.Execute<T>(request);
                T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);

                return obj;
            }
            public IEnumerable<T> GetByIdList(int id, string controller)
            {
                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/" + id, Method.GET);
                var response = client.Execute<T>(request);
                IEnumerable<T> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content);
                return obj;
            }


            public IEnumerable<T> GetByObjectList(string controller, T objeto, int id, string buscar)
            {

                var client = new RestClient(Constantes.URL_API);
                RestRequest request = new RestRequest(controller + @"/" + id + @"/" + buscar, Method.GET);
                //request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(objeto));
                var response = client.Execute<T>(request);
                IEnumerable<T> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content);
                return obj;
            }
        }
    }