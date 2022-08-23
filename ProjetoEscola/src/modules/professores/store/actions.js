/* eslint-disable */
import { Promise } from "core-js";
import HTTP from "@/utils/http";
const api = new HTTP("professores");

const listarProfessores = async ({ commit }, payload) => {
  return await api
    .get("professores", payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const listarProfessoresPorCodigo = async ({ commit }, payload) => {
  return await api
    .get(`professores/${payload.id}`)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const salvar = async ({ commit }, payload) => {
  return await api
    .post("professores", payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const remover = async ({ commit }, payload) => {
  return await api
    .delete(`professores/${payload.id}`, { data: payload })
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const atualizar = async ({ commit }, payload) => {
  return await api
    .put(`professores/${payload.id}`, payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

export default {
  listarProfessores,
  listarProfessoresPorCodigo,
  salvar,
  remover,
  atualizar,
};
