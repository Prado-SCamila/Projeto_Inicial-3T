import { Component } from "react";
import axios from "axios";

export default class Sala extends Component {
    constructor(props) {
        super(props);
        this.state = {
            // nomeEstado : valorInicialEstado
            CodSala: 0,
            Nome: [],
            Andar: [],
            Metragem: [],
        };
    };

    buscarSalas = () => {
        console.log('Esta função traz todas as salas');

        fetch('http://localhost:5000/api/sala')

            .then(resposta => {
                if (resposta.status !== 200) {
                    throw Error();
                };

                return resposta.json
            })

            .then(resposta => this.setState({ listaSala: resposta }))

            .catch(erro => console.log(erro));
    };

    componentDidMount() {
        this.buscarSalas();
    }

    cadastrarSala = (event) => {
        event.preventDefault();

        let novaSala = {
            CodSala: this.state.CodSala,
            Nome: this.state.Nome,
            Andar: this.state.Andar,
            Metragem: this.state.Metragem
        };

        axios.post('http://localhost:5000/api/sala', novaSala)

            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Uma nova sala foi cadastrada!')
                }
            })

            .catch(erro => console.log(erro))

            .then(this.buscarSalas);
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            
        )
    }
