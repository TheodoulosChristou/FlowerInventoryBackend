import { Component } from '@angular/core';
import { RouterOutlet,RouterModule } from '@angular/router';
import { NavbarComponent } from "./navbar/navbar.component";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterModule, NavbarComponent,FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'flower-frontend-app';
}
