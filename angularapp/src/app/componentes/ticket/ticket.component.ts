import { Component } from '@angular/core';
import { TicketService } from '../../ticket.service';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})

export class TicketComponent {

  eventos: string[] = [
    'Concierto',
    'Feria de Arte',
    'Festival de Cine',
  ];

  horarios: string[] = [
    '08:00', '09:00', '10:00', '11:00',
    '12:00', '13:00', '14:00', '15:00',
    '16:00', '17:00', '18:00', '19:00',
    '20:00', '21:00', '22:00'
  ];

  constructor() {
  }

  formTicket = new FormGroup({
    correo: new FormControl('', Validators.required),
    evento: new FormControl('', Validators.required),
    fecha: new FormControl('', Validators.required),
    horario: new FormControl('', Validators.required)
  });
   
  comprarTicket(){

    var data = {
      "correo": this.formTicket.value.correo ?? '',
      "evento": this.formTicket.value.evento ?? '',
      "fecha": this.formTicket.value.fecha ?? '',
      "hora": this.formTicket.value.horario ?? '',
    }

    console.log(data);
  }
}
