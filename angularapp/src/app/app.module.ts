import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms'; // Importa ReactiveFormsModule

import { AppComponent } from './app.component';
import { NavbarComponent } from './componentes/navbar/navbar.component';
import { TicketComponent } from './componentes/ticket/ticket.component';
import { AboutComponent } from './componentes/about/about.component';
import { routes } from './app.routing.module';
import { FooterComponent } from './componentes/footer/footer.component'; // Importa FooterComponent


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    TicketComponent,
    AboutComponent,
    FooterComponent 
  ], // Remove the FooterComponent from the array of declarations
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }