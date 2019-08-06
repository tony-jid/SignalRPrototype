import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { ChartModel } from '../interfaces/chart-model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: ChartModel[];
  public bradcastedData: ChartModel[];
  private hubConnection: signalR.HubConnection;

  constructor() { }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:44342/chart')
                            .build();

    this.hubConnection
                            .start()
                            .then(() => console.log('Connection started'))
                            .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferchartdata', (data) => {
      this.data = data;
      console.log(data);
    });
  }

  public broadcastChartData = () => {
    this.hubConnection.invoke('method_broadcastchartdata', this.data)
    .catch(err => console.error(err));
  }
 
  public addBroadcastChartDataListener = () => {
    this.hubConnection.on('event_broadcastchartdata', (data) => {
      this.bradcastedData = data;
    })
  }
}
