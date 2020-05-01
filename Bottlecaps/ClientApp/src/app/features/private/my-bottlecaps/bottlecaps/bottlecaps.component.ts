import { Component, OnInit} from '@angular/core';
import { Tag, Link } from '../../../../shared/models';

@Component({
  selector: 'app-bottlecaps',
  templateUrl: './bottlecaps.component.html',
  styleUrls: ['./bottlecaps.component.css']
})
export class BottlecapsComponent implements OnInit {
	title = "default";
	tags: Tag[] = [];
	links: Link[] = [];
  constructor() { }

  ngOnInit() {
  }

	addTagtoBottlecap(data) {
		if (data.value != "") {
			this.tags.push(new Tag(data.value));
		}
	}
	deleteTagtoBottlecap(data) {
		this.tags.splice(data.selectedIndex, 1);
	}
	addLinktoBottlecap(data) {
		if (data.value != "") {
			this.links.push(new Link(data.value)); // TODO: FIX PLACEHOLDERS
		}
	}
	deleteLinktoBottlecap(data) {
		this.links.splice(data.selectedIndex, 1);
	}
}
