import { Routes } from '@angular/router';
import { TAREFAS_ROUTES } from './tarefas/tarefas.routes';

export const routes: Routes = [
  {
    path: '',
    children: TAREFAS_ROUTES
  }
];