import Vue from "vue";
import { createPopper } from "@popperjs/core";
import moment from "moment";

const urlCepApi = () => {
  let url = "https://correios.grupogaia.com.br/api/address";
  return url;
};

const toastMsg = ({ text, time, type }) => {
  let typeTime = typeof time;
  let same = typeTime == "number" || typeTime == "boolean";
  let options = { timeout: same ? time : 3000 , type: type || "success" };
  Vue.$toast(text, options);
};

const validDocument = (document) => {
  let cleanDoc = "";
  cleanDoc = document.replace(/[^0-9]+/g, "");
  
  if (cleanDoc.length === 11 || cleanDoc.length === 14) {
    const validarCpfIngual = [
      "00000000000",
      "11111111111",
      "22222222222",
      "33333333333",
      "44444444444",
      "55555555555",
      "66666666666",
      "77777777777",
      "88888888888",
      "99999999999",
      "12345678900",
      "98765432100",
    ];
    
    const validarCnpjIngual = [
      "00000000000000",
      "11111111111111",
      "22222222222222",
      "33333333333333",
      "44444444444444",
      "55555555555555",
      "66666666666666",
      "77777777777777",
      "88888888888888",
      "99999999999999",
    ];

    if (cleanDoc.length == 11) {
      //CPF
      if (validarCpfIngual.includes(document)) {
        return false;
      }

      let soma = 0;
      let resto = 0;

      for (let i = 1; i <= 9; i++) soma += parseInt(cleanDoc.substring(i - 1, i)) * (11 - i);
      resto = (soma * 10) % 11;
      if (resto == 10 || resto == 11) resto = 0;
      if (resto != parseInt(cleanDoc.substring(9, 10))) {
        return false;
      }

      soma = 0;

      for (let i = 1; i <= 10; i++) soma += parseInt(cleanDoc.substring(i - 1, i)) * (12 - i);
      resto = (soma * 10) % 11;
      if (resto == 10 || resto == 11) resto = 0;
      if (resto != parseInt(cleanDoc.substring(10, 11))) {
        return false;
      }

      return true;
    }

    if (cleanDoc.length == 14) {
      //CNPJ
      if (validarCnpjIngual.includes(document)) {
        return false;
      }

      let tamanho = cleanDoc.length - 2;
      let numeros = cleanDoc.substring(0, tamanho);
      let digitos = cleanDoc.substring(tamanho);
      let soma = 0;
      let pos = tamanho - 7;

      for (let i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) pos = 9;
      }

      let resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);

      if (resultado != digitos.charAt(0)) {
        return false;
      }

      tamanho = tamanho + 1;
      numeros = cleanDoc.substring(0, tamanho);
      soma = 0;
      pos = tamanho - 7;

      for (let i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2) pos = 9;
      }

      resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);

      if (resultado != digitos.charAt(1)) {
        return false;
      }

      return true;
    }

    return true;
  } else {
    return false;
  }
};

const positionWithPopper = (dropdownList, component, { width }) => {
  dropdownList.style.width = width
  const popper = createPopper(component.$refs.toggle, dropdownList, { placement: 'bottom' })
  return () => popper.destroy()
}

const normValue = (val) => {
  if (typeof val == "number") {
    return val.toFixed(2).replace(".", ",");
  }
  return val;
};

const valueExists = ({ value, obj, key }) => {
  let resp = false;
  Array.from(obj).forEach((o) => {
    if (o[key] == value) resp = true;
  });

  return resp;
};

const dateHigherToday = (date) => {
  if (!date) {
    return false;
  }

  let normDate = date.replace("/", "-");
  let todayDate = moment(new Date());
  
  if (!todayDate.isAfter(normDate)) {
    return true;
  }

  return false;
};


export default {
  urlCepApi,
  toastMsg,
  validDocument,
  positionWithPopper,
  normValue,
  valueExists,
  dateHigherToday,
};
