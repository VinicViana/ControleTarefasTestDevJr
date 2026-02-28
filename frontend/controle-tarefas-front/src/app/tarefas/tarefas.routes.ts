import { Routes } from '@angular/router';
import { TarefasListComponent } from './pages/tarefas-list/tarefas-list.component';
import { TarefaFormComponent } from './pages/tarefa-form/tarefa-form.component';

export const TAREFAS_ROUTES: Routes = [
  { path: '', component: TarefasListComponent },
  { path: 'nova', component: TarefaFormComponent },
  { path: 'editar/:id', component: TarefaFormComponent }
];