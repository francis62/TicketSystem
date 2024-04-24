import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private apiUrl = 'http://localhost:5274';

  constructor(private http: HttpClient) { }

  comprarTicket(correo: string, evento: string, fecha: string, horario: string): Observable<any> {
    const ticket = {
      EventoId: evento,
      FechaSeleccionada: fecha,
      HorarioSeleccionado: horario,
      Email: correo
    };
    return this.http.post<any>(`${this.apiUrl}/api/Eventos/reservar`, ticket);
  }
}
