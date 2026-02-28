import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TarefasService } from '../../services/tarefa.service';

@Component({
  selector: 'app-tarefa-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './tarefa-form.component.html',
  styleUrls: ['./tarefa-form.component.css']
})

export class TarefaFormComponent implements OnInit {

  form: any;
  editando = false;

  constructor(
    private fb: FormBuilder,
    private service: TarefasService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.form = this.fb.group({
      id: [0],
      titulo: [''],
      descricao: [''],
      prioridade: [0],
      status: [0]
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.editando = true;
      this.service.buscarPorId(+id).subscribe(tarefa => {
        this.form.patchValue(tarefa);
      });
    }
  }

  salvar() {
    const tarefa = this.form.value;

    if (this.editando) {
      this.service.atualizar(tarefa).subscribe(() => {
        this.router.navigate(['/']);
      });
    } else {
      this.service.criar(tarefa).subscribe(() => {
        this.router.navigate(['/']);
      });
    }
  }

  voltar() {
    this.router.navigate(['/']);
  }
}