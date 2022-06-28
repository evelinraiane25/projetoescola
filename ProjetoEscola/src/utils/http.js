/* eslint-disable */
import axios from "axios";
//import qs from 'qs';
import helpers from "@/utils/helpers";

class HTTP {  
  constructor(url) {
    let startUrl = process.env.VUE_APP_SERVICE_URL;
    var instance = axios.create({
      baseURL: startUrl,
      json: true,
    });

    instance.interceptors.request.use(
      function(config) {
        return config;
      },
      function(error) {
        return Promise.reject(error);
      }
    );

    instance.interceptors.response.use(
      function(response) {
        return response;
      },
      function(error) {
        callsPending--;
        if (error.response) {
          let status = error.response.status;
          if(status === 400 || status === 401 || status === 403) {
            let err = error.response.data.Errors;
            Array.from(err).forEach((error) => helpers.toastMsg({ text: error.Message, time: 5000, type: "error" }));
          }
          else if (status === 500) {
            let errDefault ="Ocorreu um erro no sistema, por favor, tente novamente mais tarde.";
            helpers.toastMsg({ text: errDefault, time: 7000, type: "error" });
          }
        }
        return Promise.reject(error);
      }
    );

    instance.url = url;

    instance.getOne = function(id) {
      return this.get(this.url + `/${id}`);
    };

    instance.getAll = function() {
      return this.get(this.url);
    };

    instance.find = function (data) {
      let url = this.url;
      //if (data) url = url + '?' + qs.stringify(data);
      return this.get(url);
    };

    instance.update = function(id, toUpdate) {
      return this.put(this.url + `/${id}`, toUpdate);
    };

    instance.create = function(toCreate) {
      return this.post(this.url, toCreate);
    };

    instance.remove = function(id) {
      return this.delete(this.url + `/${id}`);
    };

    return instance;
  }
}

export default HTTP;
