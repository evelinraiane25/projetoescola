import Vue from "vue";
import moment from "moment";

moment.locale("pt-br");
const myFormat = "DD/MM/YYYY";
const myFormatEUA = "YYYY-MM-DD";
Vue.prototype.$myMoment = moment;

export const formatDate = (d) => {
  if (!d) return "";
  return moment(d).format(myFormat);
};

export const formatDateEUA = (d) => {
  if (d === undefined || d === null) return "";
  return moment(d, myFormat).format(myFormatEUA);
};

export const formatMoney = (amount, preffix = "R$ ", decimalCount = 2, decimal = ",", thousands = ".") => {
  if (amount == 0) return `${preffix}0,00`; // se o valor for 0, retorna o 0
  try {
    if (typeof amount == "string") amount = amount.replace(",", ".");

    decimalCount = Math.abs(decimalCount);
    decimalCount = isNaN(decimalCount) ? 2 : decimalCount;

    const negativeSign = amount < 0 ? "-" : "";

    amount = typeof amount === "string" ? amount.replace(",", ".") : amount;

    let i = parseInt((amount = Math.abs(Number(amount) || 0).toFixed(decimalCount))).toString();
    let j = i.length > 3 ? i.length % 3 : 0;

    return (
      preffix +
      negativeSign +
      (j ? i.substring(0, j) + thousands : "") +
      i.substring(j).replace(/(\d{3})(?=\d)/g, "$1" + thousands) +
      (decimalCount
        ? decimal +
          Math.abs(amount - i)
            .toFixed(decimalCount)
            .slice(2)
        : "")
    );
  } catch (e) {
    console.log(e);
  }
};

export const removeSpecials = (str) => {
  if (str !== undefined && str !== null) {
    return str.replace(/[^0-9]+/g, "");
  }
  return str;
};

const formatDocument = (str) => {
  if (!str) return "Não informado";
  str = str.replace(/[^\d]/g, "");
  if (str && str.length === 11) {
    return str.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
  } else if (str && str.length === 14) {
    return str.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
  }
  return str;
};

const formatPhone = (str) => {
  if (!str) return "Não informado";
  str = str.replace(/[^\d]/g, "");
  if (str && str.length === 10) {
    return str.replace(/(\d{2})(\d{4})(\d{4})/, "($1) $2-$3");
  } else if (str && str.length === 11) {
    return str.replace(/(\d{2})(\d{5})(\d{4})/, "($1) $2-$3");
  }
  return str;
};

const statusPTBR = (status) => {
  return (
    {
      APPROVED: "Aprovada",
      REPROVED: "Reprovado",
      REGISTERED: "Registrado",
      PENDING: "Pendente",
      STARTED: "Iniciado",
      SENT: "Enviada",
      IN_ANALYZE: "Em Análise",
      EXPIRED: "Expirada",
      FORMALIZED: "Formalizada",
      LIQUIDED: "Liquidada",
      DEFAULTING: "Inadimplente",
      EXECUTED: "Executada",
      PAID: "Quitada",
      FINISHED: "Finalizada",
      ACTIVED: "Ativa",
    }[status] || "Indefinido"
  );
};

const typesParticipantsPTBR = (type) => {
  if (!type) return "Não informado";
  return type === "PF" ? "Pessoa Física" : type === "PJ" ? "Pessoa Jurídica" : "Indefinido";
};

const classificationPTBR = (classification) => {
  if (!classification) return "Não informado";
  return classification === "GREAT" ? "Grande" : classification === "MEDIUM" ? "Médio" : classification === "SMALL" ? "Pequeno" : "Indefinido";
};

const typesSponsorsPTBR = (classification) => {
  return (
    {
      DISTRIBUTOR: "Distribuidor",
      RESALE: "Revenda",
      INDUSTRY: "Indústria",
      COOPERATIVE: "Cooperativa",
    }[classification] || "Indefinido"
  );
};

const typesEconomicGroup = (type) => {
  return (
    {
      Partner: "Parceiro",
      Associate: "Sócio",
    }[type] || "Indefinido"
  );
};

const typesQualification = (qualification) => {
  if (!qualification) return "Não informado";
  return qualification === "Issuer" ? "Emissor" : qualification === "Assignor" ? "Cedente" : "Indefinido";
};

const paymentPeriod = (paymentPeriod) => {
  return (
    {
      HARVEST: "Safra",
      UNIQUE: "Única",
      DAILY: "Diária",
      MONTHLY: "Mensal",
      BIMONTHLY: "Bimestral",
      QUARTERLY: "Trimestral",
      SEMIANNUAL: "Semestral",
      ANNUAL: "Anual",
    }[paymentPeriod] || "Indefinido"
  );
};

const parseEUADate = (str) => {
  if (str !== undefined && str !== null && str !== "") {
    return moment(str.substr(0, 10), "DD/MM/YYYY", true).format("YYYY-MM-DD");
  }
  return str;
};

Vue.filter("formatDate", formatDate);
Vue.filter("formatDateEUA", formatDateEUA);
Vue.filter("formatMoney", formatMoney);
Vue.filter("removeSpecials", removeSpecials);
Vue.filter("formatDocument", formatDocument);
Vue.filter("formatPhone", formatPhone);
Vue.filter("statusPTBR", statusPTBR);
Vue.filter("typesParticipantsPTBR", typesParticipantsPTBR);
Vue.filter("classificationPTBR", classificationPTBR);
Vue.filter("typesSponsorsPTBR", typesSponsorsPTBR);
Vue.filter("typesEconomicGroup", typesEconomicGroup);
Vue.filter("typesQualification", typesQualification);
Vue.filter("paymentPeriod", paymentPeriod);

export default {
  formatDate,
  formatDateEUA,
  formatMoney,
  removeSpecials,
  formatDocument,
  formatPhone,
  paymentPeriod,
  parseEUADate,
  statusPTBR,
};
