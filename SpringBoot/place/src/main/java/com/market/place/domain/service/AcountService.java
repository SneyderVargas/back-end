package com.market.place.domain.service;

import com.market.place.domain.UserDomain;
import com.market.place.domain.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class AcountService {
    @Autowired
    private UserRepository userRepository;
    public List<UserDomain> getAll(){
        return userRepository.getAll();
    }
}
