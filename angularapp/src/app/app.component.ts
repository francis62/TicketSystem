import { Component } from '@angular/core';
import { TicketService } from './ticket.service';

interface Evento {
  id: number;
  nombre: string;
  horarios: string[];
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  correo!: string;
  eventoSeleccionado!: any; // Cambiado a número para representar el id del evento
  eventoIdSeleccionado: number | undefined; // Variable para almacenar el ID del evento seleccionado
  fecha!: string;
  horarioSeleccionado!: string;

  eventos: Evento[] = [
    { id: 1, nombre: 'Concierto', horarios: ['18:00', '20:00', '22:00'] },
    { id: 2, nombre: 'Feria de Arte', horarios: ['10:00', '12:00', '14:00'] },
    { id: 3, nombre: 'Festival de Cine', horarios: ['15:00', '17:00', '19:00'] }
    // Agregar más eventos y horarios aquí
  ];

  horariosDisponibles: string[] = [];

  constructor(private ticketService: TicketService) { }

  seleccionarEvento(event: Event) {
    const target = event.target as HTMLSelectElement;
    if (target && target.value) {
      // Convertir el id del evento a un número
      const idEvento = parseInt(target.value);

      // Asignar el ID del evento seleccionado a la variable eventoIdSeleccionado
      this.eventoIdSeleccionado = idEvento;

      // Buscar el evento por su id
      const eventoEncontrado = this.eventos.find(e => e.id === idEvento);
      if (eventoEncontrado) {
        this.horariosDisponibles = eventoEncontrado.horarios;
      }
    }
  }

  comprarTicket(formulario: any) {
    console.log(this.correo);
    console.log(this.eventoIdSeleccionado);
    console.log(this.fecha);
    console.log(this.horarioSeleccionado);
    if (formulario.valid) {
      // Verificar si se ha seleccionado un evento
      if (this.eventoIdSeleccionado) {
        const idEvento = this.eventoIdSeleccionado.toString();

        console.log(this.correo);
        console.log(this.eventoIdSeleccionado);
        console.log(this.fecha);
        console.log(this.horarioSeleccionado);

        // Llamar al servicio para comprar el ticket
        this.ticketService.comprarTicket(this.correo, idEvento, this.fecha, this.horarioSeleccionado)
          .subscribe(
            () => {
              alert('¡Ticket comprado exitosamente! Se ha enviado la confirmación por correo electrónico.');
              // Limpiar el formulario después de la compra exitosa
              formulario.reset();
            },
            (error) => {
              console.error('Error al comprar el ticket:', error);
              alert('Ha ocurrido un error al comprar el ticket. Por favor, inténtalo de nuevo.');
            }
          );
      } else {
        console.log(this.correo);
        console.log(this.eventoIdSeleccionado);
        console.log(this.fecha);
        console.log(this.horarioSeleccionado);
        console.error('No se ha seleccionado un evento.');
        // Manejar el caso en que no se ha seleccionado un evento
      }
    }
  }
}
