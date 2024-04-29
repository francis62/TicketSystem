import { Routes } from '@angular/router';
import { AboutComponent } from './componentes/about/about.component'; 
import { TicketComponent } from './componentes/ticket/ticket.component';

export const routes: Routes = [
    { path: 'ticket', component: TicketComponent },
    { path: 'about', component: AboutComponent },
    { path: '', redirectTo: '/ticket', pathMatch: 'full' }
  ];