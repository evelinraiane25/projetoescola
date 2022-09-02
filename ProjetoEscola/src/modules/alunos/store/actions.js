/* eslint-disable */
import { Promise } from "core-js";
import HTTP from "@/utils/http";
const api = new HTTP("alunos");

const listarAlunos = async ({ commit }, payload) => {
  return await api
    .get(`alunos`, payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const listarAlunosPorCodigoProfessor = async ({ commit }, payload) => {
  return await api
    .get(`alunos/professor/${payload.id}`)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const listarAlunosPorCodigo = async ({ commit }, payload) => {
  return await api
    .get(`alunos/${payload.id}`)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const salvar = async ({ commit }, payload) => {
  return await api
    .post("alunos", payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const remover = async ({ commit }, payload) => {
  return await api
    .delete(`alunos/${payload.id}`, { data: payload })
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

const atualizar = async ({ commit }, payload) => {
  return await api
    .put(`alunos/${payload.id}`, payload)
    .then(async (resp) => {
      return Promise.resolve(resp);
    })
    .catch((err) => {
      return Promise.reject(err);
    });
};

export default {
  listarAlunos,
  listarAlunosPorCodigo,
  listarAlunosPorCodigoProfessor,
  salvar,
  remover,
  atualizar,
};
