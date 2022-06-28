/* eslint-disable */
import { Promise } from "core-js";
import HTTP from "@/utils/http";
const api = new HTTP("professores");
import qs from 'qs';

const listarTodos = async ({ commit }, payload) => {
  let url = "professores";

  if (payload) url = url + "?" + qs.stringify(payload);

  return await api
    .get(url, payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const listarPorCodigo = async ({ commit }, payload) => {
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
    .put(`/professores/${payload.id}`, payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

export default {
  listarTodos,
  listarPorCodigo,
  salvar,
  remover,
  atualizar,
};
