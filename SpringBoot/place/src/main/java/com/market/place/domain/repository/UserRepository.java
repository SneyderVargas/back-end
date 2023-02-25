package com.market.place.domain.repository;

import com.market.place.domain.UserItem;

import java.util.List;
import java.util.Optional;

public interface UserRepository {
    List<UserItem> getAll();
    Optional<List<UserItem>> getById(String clienteId);
}
