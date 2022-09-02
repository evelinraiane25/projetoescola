<template>
  <div>
    <titulo
      :texto="
        professorId != undefined
          ? `Professor: ${professor.nome}`
          : 'Todos os alunos'
      "
    />
    <div v-if="this.$route.params.professorid">
      <input
        type="text"
        placeholder="Nome"
        v-model="nome"
        @keyup.enter="adicionar()"
      />
      <button class="btn btnInput" @click="adicionar()">Adicionar</button>
    </div>

    <br />
    <br />

    <table>
      <thead>
        <th>#</th>
        <th>Nome</th>
        <th>Opões</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="center">{{ aluno.id }}</td>
          <router-link
            :to="`/alunos/detalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer"
          >
            {{ aluno.nome }} {{ aluno.sobrenome }}
          </router-link>
          <td class="center">
            <button class="btn btnDanger" @click="apagar(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum aluno encontrado</h5>
          </td>
        </tr>
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
      professorId: this.$route.params.professorid,
      professor: [],
    };
  },

  methods: {
    /* eslint-disable */
    ...mapActions({
      listarAlunos: "alunos/listarAlunos",
      listarProfessores: "professores/listarProfessores",
      listarAlunosPorCodigoProfessor: "alunos/listarAlunosPorCodigoProfessor",
      listarProfessoresPorCodigo: "professores/listarProfessoresPorCodigo",
      salvar: "alunos/salvar",
      remover: "alunos/remover",
      atualizar: "alunos/atualizar",
    }),

    //Created
    carregar() {
      if (this.professorId) {
        this.carregarProfessores();
        this.listarAlunosPorCodigoProfessor({ id: this.professorId }).then(
          (resposta) => (this.alunos = resposta.data)
        );
      } else {
        this.listarAlunos().then((resposta) => {
          this.alunos = resposta.data;
        });
      }
    },

    adicionar() {
      let aluno = {
        nome: this.nome,
        sobrenome: this.sobrenome,
        nascimento: "",
        professorId: this.professor.id,
      };

      this.salvar({ ...aluno }).then(() => {
        this.alunos.push(aluno);
        this.nome = "";
        this.sobrenome = "";

        this.carregar();
      });
    },

    apagar(aluno) {
      this.remover({ id: aluno.id }).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },

    carregarProfessores() {
      this.listarProfessoresPorCodigo({ id: this.professorId }).then((res) => {
        this.professor = res.data;
      });
    },
  },

  mounted() {
    this.carregar();
  },
};
</script>