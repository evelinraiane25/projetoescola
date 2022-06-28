<template>
  <div>
    <titulo texto="Alunos" />
    <div>
      <input type="text" placeholder="Nome" v-model="nome" @keyup.enter="adicionar()" />
      &nbsp;
      <input type="text" placeholder="Sobrenome" v-model="sobrenome" @keyup.enter="adicionar()" />
      &nbsp;
      <button class="btn btnInput" @click="adicionar()">Adicionar</button>
    </div>

    <br />
    <br />

    <table>
      <thead>
        <th>#</th>
        <th>Nome</th>
        <th>Sobrenome</th>
        <th>Opões</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{ aluno.id }}</td>
          <td>{{ aluno.nome }}</td>
          <td>{{ aluno.sobrenome }}</td>
          <td>
            <button class="btn btnDanger" @click="apagar(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum aluno encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../../shared/views/titulo";
import { mapActions } from "vuex";

export default {
  name: "Alunos",
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Alunos",
      nome: "",
      sobrenome: "",
      alunos: [],
    };
  },
  methods: {
    /* eslint-disable */
    ...mapActions({
      listarTodos: "alunos/listarTodos",
      listarPorCodigo: "alunos/listarPorCodigo",
      salvar: "alunos/salvar",
      remover: "alunos/remover",
      atualizar: "alunos/atualizar",
    }),

    listar() {
      this.alunos = [];
      this.listarTodos().then((resposta) => (this.alunos = resposta.data));
    },

    adicionar() {
      let aluno = {
        nome: this.nome,
        sobrenome: this.sobrenome,
      };

      this.salvar({ nome: aluno.nome, sobrenome: aluno.sobrenome }).then(() => {
        this.alunos.push(aluno);
        this.nome = "";
        this.sobrenome = "";

        this.listar();
      });
    },

    apagar(aluno) {
      this.remover({ id: aluno.id }).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
  },
  mounted() {
    this.listar();
  },
};
</script>