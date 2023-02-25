package com.market.place.persistence;

import com.market.place.domain.UserItem;
import com.market.place.domain.repository.UserRepository;
import com.market.place.persistence.crud.UserCrudRepository;
import com.market.place.persistence.entity.User;
import com.market.place.persistence.mapper.UserItemMapper;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;
import java.util.Optional;

public class UsersRepository implements UserRepository {
    @Autowired
    private UserCrudRepository userCrudRepository;
    @Autowired
    private UserItemMapper userItemMapper;
    @Override
    public List<UserItem> getAll() {
        List<User> userItems = (List<User>) userCrudRepository.findAll();
        return userItemMapper.toUsersItem(userItems);
    }

    @Override
    public Optional<List<UserItem>> getById(String clienteId) {
        return Optional.empty();
    }
}
