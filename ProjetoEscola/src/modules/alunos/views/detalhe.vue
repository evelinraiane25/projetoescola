<template>
  <div>
    <titulo :texto="`Aluno: ${alunos.nome}`" :btnVoltar="true">
      <button v-show="visualizando" class="btb btnEditar" @click="editar()">
        Editar
      </button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label v-if="visualizando">{{ alunos.id }}</label>
            <input v-else v-model="alunos.id" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{ alunos.nome }}</label>
            <input v-else v-model="alunos.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{ alunos.sobrenome }}</label>
            <input v-else v-model="alunos.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="visualizando">{{ alunos.nascimento }}</label>
            <input
              v-else
              v-model="alunos.nascimento"
              type="text"
              placeholder="dd/mm/aaaa"
            />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando">{{
              alunos.professor && alunos.professor.nome
            }}</label>
            <select v-else v-model="alunos.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor.id"
              >
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar(alunos)">salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../../shared/views/titulo";
import { mapActions } from "vuex";

export default {
  name: "AlunoDetalhe",
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      alunos: [],
      alunoid: this.$route.params.id,
      visualizando: true,
    };
  },

  methods: {
    /* eslint-disable */
    ...mapActions({
      listarAlunosPorCodigo: "alunos/listarAlunosPorCodigo",
      listarProfessores: "professores/listarProfessores",
      atualizar: "alunos/atualizar",
    }),

    //Created
    carregar() {
      this.listarAlunosPorCodigo({ id: this.alunoid }).then((resposta) => {
        this.alunos = resposta.data;
      });

      this.listarProfessores().then((res) => {
        this.professores = res.data;
      });
    },

    editar() {
      this.visualizando = !this.visualizando;
    },

    salvar(_aluno) {
      let _alunoEditar = {
        id: _aluno.id,
        nome: _aluno.nome,
        sobrenome: _aluno.sobrenome,
        nascimento: _aluno.nascimento,
        professorId: _aluno.professor.id,
      };

      console.log(_aluno.professor);

      this.atualizar({ id: _aluno.id, ..._alunoEditar }).then(
        (resposta) => (this.alunos = resposta.data)
      );
    },

    cancelar() {
      this.visualizando = !this.visualizando;
    },
  },

  mounted() {
    this.carregar();
  },
};
</script>