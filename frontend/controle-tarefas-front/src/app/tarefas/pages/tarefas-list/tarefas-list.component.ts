import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Tarefa } from '../../models/tarefa.model';
import { TarefasService } from '../../services/tarefa.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tarefas-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tarefas-list.component.html',
  styleUrls: ['./tarefas-list.component.css']
})
export class TarefasListComponent implements OnInit {

  tarefas: Tarefa[] = [];

  constructor(
    private service: TarefasService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.carregar();
  }

carregar() {
  console.log('entrou no carregar');

  this.service.listar().subscribe({
    next: (res) => {
      console.log('Response');
      console.log(res);
      this.tarefas = res;
    },
    error: (err) => {
      console.error('Erro na requisição:');
      console.error(err);
    }
  });
}

  novaTarefa() {
    this.router.navigate(['/nova']);
  }

  editar(id: number) {
    this.router.navigate(['/editar', id]);
  }

excluir(id: number) {

  Swal.fire({
    title: 'Tem certeza?',
    text: 'Essa ação não poderá ser desfeita!',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#dc2626',
    cancelButtonColor: '#6b7280',
    confirmButtonText: 'Sim, excluir!',
    cancelButtonText: 'Cancelar'
  }).then((result) => {

    if (result.isConfirmed) {

      this.service.excluir(id).subscribe({
        next: () => {

          Swal.fire({
            title: 'Excluído!',
            text: 'A tarefa foi removida com sucesso.',
            icon: 'success',
            timer: 1500,
            showConfirmButton: false
          });

          this.carregar();
        },
        error: () => {
          Swal.fire({
            title: 'Erro!',
            text: 'Não foi possível excluir a tarefa.',
            icon: 'error'
          });
        }
      });

    }

  });

}

  getPrioridadeTexto(valor: number): string {
  switch (valor) {
    case 0: return 'Baixa';
    case 1: return 'Média';
    case 2: return 'Alta';
    default: return '';
  }
}

getStatusTexto(valor: number): string {
  switch (valor) {
    case 0: return 'Pendente';
    case 1: return 'Em Andamento';
    case 2: return 'Concluído';
    default: return '';
  }
}
}