import { Component } from '@angular/core';
import { RouterOutlet,RouterModule } from '@angular/router';
import { FlowersComponent } from './AppComponents/flowers/flowers.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,RouterModule,FlowersComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'flower-frontend-app';
}
