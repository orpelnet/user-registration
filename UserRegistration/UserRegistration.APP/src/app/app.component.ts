import { Component, OnInit, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { UsuarioService } from './services/usuario.service';
import { EscolaridadeService } from './services/escolaridade.service'
import { Usuario } from './models/usuario';
import { Escolaridade } from './models/escolaridade';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  Usuario = {} as Usuario;
  Usuarios: Usuario[] | undefined;
  Escolaridades: Escolaridade[] | undefined;

  constructor(private UsuarioService: UsuarioService
    ,private EscolaridadeService: EscolaridadeService) {}
  
  ngOnInit() {
    this.getUsuarios();
    this.getEscolaridade();
  }

  // defini se um Usuario será criado ou atualizado
  saveUsuario(form: NgForm) {
    if (this.Usuario.id !== undefined) {
      this.UsuarioService.updateUsuario(this.Usuario).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.UsuarioService.saveUsuario(this.Usuario).subscribe(() => {
        this.cleanForm(form);
      });
    }
  }

  // Chama o serviço para obtém todos os Usuarios
  getUsuarios() {
    this.Usuarios = []
    this.UsuarioService.getUsuarios().subscribe((Usuarios: Usuario[]) => {
      this.Usuarios = Usuarios;
    });
  }

  // deleta um Usuarios
  deleteUsuario(Usuario: Usuario) {
    this.UsuarioService.deleteUsuario(Usuario).subscribe(() => {
      this.getUsuarios();
    });
  }

  downloadHistoricoUsuario(Usuario: Usuario){
    if(Usuario.historico.formato === "DOC"){
        //Gera Histórico em DOC
        alert('download DOC')
    }
    else{
      //Gera Histórico em PDF
      alert('download PDF')
    }
  }

  // Chama o serviço para obtém todos os Usuarios
  getEscolaridade() {
    this.Escolaridades = []
    this.EscolaridadeService.getEscolaridade().subscribe((Escolaridades: Escolaridade[]) => {
      this.Escolaridades = Escolaridades;
    });
  }

  // copia o Usuario para ser editado.
  editUsuario(Usuario: Usuario) {
    this.Usuario = { ...Usuario };
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    this.getUsuarios();
    form.resetForm();
    this.Usuario = {} as Usuario;
  }

}
