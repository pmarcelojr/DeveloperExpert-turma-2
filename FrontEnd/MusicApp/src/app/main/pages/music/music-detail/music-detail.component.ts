import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import Album from "app/model/album.model";
import Music from "app/model/music.model";
import { MusicService } from "app/services/music.service";
import { forkJoin } from "rxjs";
import Swal from "sweetalert2";

@Component({
    selector: "app-music-detail",
    templateUrl: "./music-detail.component.html",
    styleUrls: ["./music-detail.component.scss"],
})
export class MusicDetailComponent implements OnInit {
    private albumId: string;
    album: Album[];

    constructor(private service: MusicService,
        private router: Router,
        private route: ActivatedRoute
    ) {}

    ngOnInit() {
        this.albumId = this.route.snapshot.paramMap.get("id");
        
        this.service.getAlbumsDetail(this.albumId).subscribe(data => {
            this.album = data;
        });
    }

    getMusicDuration(value: number) {
        const minutes: number = Math.floor(value / 60);
        return `${minutes.toString().padStart(2, "0")}:${(value - minutes * 60).toString().padStart(2, "0")}`;
    }

    back() {
        this.router.navigate(["page", "music"]);
    }
}
