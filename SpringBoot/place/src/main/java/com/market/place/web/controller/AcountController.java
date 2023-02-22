package com.market.place.web.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/acount")
public class AcountController {
    @GetMapping("/status")
    public String status (){
        return "Status Ok";
    }
}
