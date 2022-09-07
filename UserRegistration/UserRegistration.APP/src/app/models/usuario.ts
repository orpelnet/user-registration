import { Escolaridade } from './escolaridade';
import { HistoricoEscolar } from './HistoricoEscolar';

export interface Usuario {
    id: number;
    nome: string;
    sobrenome: string;
    email: string;
    dataNascimento: Date;
    escolaridadeId: number;
    historicoEscolarId: number;
    escolaridadeDescricao: string;
    escolaridade: Escolaridade;
    historico: HistoricoEscolar;
}
